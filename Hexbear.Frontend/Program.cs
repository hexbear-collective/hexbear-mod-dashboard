global using Hexbear.Lib.EFCore;
using Hexbear.Lib;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using MudBlazor.Services;

namespace Hexbear.Frontend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            var appsettings = new Appsettings(builder.Configuration);
            if (builder.HostEnvironment.IsProduction())
            {
                builder.Logging.SetMinimumLevel(LogLevel.Warning);
            }
            builder.Services.AddMudServices();
            builder.Services.AddTransient<CustomMessageHandler>();
            builder.Services.AddTransient<CookieHandler>()
                .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"))
                .AddHttpClient("API", client => client.BaseAddress = new Uri(appsettings.APIUrl)).AddHttpMessageHandler<CookieHandler>().AddHttpMessageHandler<CustomMessageHandler>();

            builder.Services.AddSingleton<HexbearAPIClient>();

            await builder.Build().RunAsync();
        }
    }

    /// <summary>
    /// Make sure jwt cookie gets passed to httpclient
    /// </summary>
    public class CookieHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            return await base.SendAsync(request, cancellationToken);
        }
    }

    public class CustomMessageHandler : DelegatingHandler
    {
        readonly NavigationManager _navigationManager;

        public CustomMessageHandler(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("/Unauthorized", forceLoad: true);
            }

            return response;
        }
    }
}
