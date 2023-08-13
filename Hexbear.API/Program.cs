using Hexbear.Lib;
using Hexbear.Lib.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Hexbear.API
{
    public class Program
    {
        public static string JWT_SECRET;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Host.UseDefaultServiceProvider(o =>
            {
                o.ValidateScopes = true;
                o.ValidateOnBuild = false;
            });

            var appsettings = new Appsettings(builder.Configuration);
            builder.Services.AddDbContext<LemmyContext>(opt => { opt.UseNpgsql(appsettings.ConnectionString, pgOpt => { pgOpt.CommandTimeout(120); }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); });
            builder.Services.AddScoped<LoggedInUser>();
            builder.Services.AddSingleton(appsettings);
            builder.Services.AddCors();
            builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
            {
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            var app = builder.Build();
            app.UseCors(x => x
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials()
            );
            app.UseHttpsRedirection();
            app.UseAuthMiddleware();

            //Load jwt secret for auth
            var optionsBuilder = new DbContextOptionsBuilder<LemmyContext>();
            optionsBuilder.UseNpgsql(appsettings.ConnectionString, pgOpt => { pgOpt.CommandTimeout(120); });
            var db = new LemmyContext(optionsBuilder.Options);
            JWT_SECRET = db.Secrets.First().JwtSecret;

            Routing.Route(app);

            app.Run();
        }
    }

    public class LoggedInUser
    {
        public LocalUser LocalUser { get; set; }
    }

    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        // IMessageWriter is injected into InvokeAsync
        public async Task InvokeAsync(HttpContext context, LoggedInUser user, LemmyContext db)
        {
            var authCookie = context.Request.Cookies["jwt"];
            if (authCookie != null)
            {
                var key = Encoding.ASCII.GetBytes(Program.JWT_SECRET);
                var handler = new JwtSecurityTokenHandler();
                var validations = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = false,
                };
                var claims = handler.ValidateToken(authCookie, validations, out var tokenSecure);
                var userId = Convert.ToInt32(claims.Claims.First().Value);
                user.LocalUser = await db.LocalUsers.Include(x => x.Person).FirstAsync(x => x.Id == userId);
            }
            if (!(user?.LocalUser?.Person?.Admin ?? false))
            {
                context.Response.Clear();
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
            await _next(context);
        }
    }

    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}