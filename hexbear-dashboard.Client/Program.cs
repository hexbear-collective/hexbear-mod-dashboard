using Hexbear.Lib;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.Extensions.Caching.Memory;
using Radzen;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        var appsettings = new Appsettings(builder.Configuration);
        if (builder.HostEnvironment.IsProduction())
        {
            builder.Logging.SetMinimumLevel(LogLevel.Warning);
        }

        builder.Services.AddRadzenComponents();
        builder.Services.AddTransient<CustomMessageHandler>();
        builder.Services.AddTransient<CookieHandler>()
            .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"))
            .AddHttpClient("API", client => {
                client.BaseAddress = new Uri(appsettings.APIUrl);
                client.Timeout = TimeSpan.FromMinutes(10);
            }).AddHttpMessageHandler<CookieHandler>().AddHttpMessageHandler<CustomMessageHandler>();
        builder.Services.AddSingleton<MemoryCache>();
        builder.Services.AddSingleton<HexbearAPIClient>();

        await builder.Build().RunAsync();
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

    public class Appsettings
    {
        public string APIUrl { get; set; }
        public Appsettings(IConfiguration config)
        {
            this.APIUrl = config.GetValue<string>("APIUrl");
        }
    }
}