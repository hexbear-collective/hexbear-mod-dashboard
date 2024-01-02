using Hexbear.Lib.Models;
using Microsoft.Extensions.Caching.Memory;

namespace hexbear_dashboard.Client.Components.Pages;
public partial class ListReports
{
    public List<ReportItem> ReportItems { get; set; }
    protected override async Task OnInitializedAsync()
    {
        var res = await _cache.GetOrCreateAsync("Reports", async (i) =>
        {
            var reports = await _client.GetReports();
            return reports;
        });
        
        this.ReportItems = res.ReportItems;
        await base.OnInitializedAsync();
        return;
    }
}
