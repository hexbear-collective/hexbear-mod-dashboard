using Hexbear.API.Services;
using Hexbear.Lib.EFCore;
using Hexbear.Lib.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Hexbear.API
{
    public static class Routing
    {

        public static void Route(WebApplication app)
        {
            app.MapGet("/ListUsers", async (LemmyContext db) =>
            {
                var service = new UserService();
                var result = await service.ListUsers(db);
                return result;
            });
            app.MapGet("/u/{username}", async (string username,LemmyContext db) =>
            {
                var service = new UserService();
                var result = await service.GetUserByName(db, username);
                if (result == null)
                    return Results.NotFound();
                
                return Results.Ok(result);
            });
            app.MapGet("/ListReports", async (LemmyContext db) =>
            {
                var service = new ReportService();
                var result = await service.ListReports(db);
                return result;
            });
            app.MapGet("/ListLogs", async () =>
            {
                var service = new LogService();
                var result = await service.ListLogs();
                return result;
            });
        }
    }
}
