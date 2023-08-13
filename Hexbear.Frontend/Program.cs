global using Hexbear.Lib.EFCore;
using Hexbear.Lib;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
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
            builder.Services.AddMudServices();
            builder.Services.AddTransient<CookieHandler>()
                .AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("API"))
                .AddHttpClient("API", client => client.BaseAddress = new Uri("https://localhost:7082")).AddHttpMessageHandler<CookieHandler>();

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
}

//I would say being able to search reports would be nice.

//Being able to see if someone is abusing reports by making lots

//Being able to see if a user has a lot of reports against them

//Being able to see/show that a mod action had a report behind it

//A community mod page tab off /reports that shows a list of users with a list of their reports/mod actions against

//Modmail of some sorts, like if there was a way for a user to send a direct message to the community and all the moderators are able to see it / interact.  Essentially the user DMs modmail which then creates a direct message with all the moderators like a mini email group
//Being able to remove comments or posts from the report screen (report reason box included)

//yeah, total list of a user’s reported comments / posts. also potentially something with being able to see how many removed comments / posts they have previously upvoted. useful for sock puppet detection.