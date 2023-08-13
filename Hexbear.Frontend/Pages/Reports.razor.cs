using Hexbear.Lib.Models;

namespace Hexbear.Frontend.Pages;
public partial class Reports
{
    public List<ReportItem> ReportItems { get; set; }
    protected override async Task OnInitializedAsync()
    {
        var reports = await _client.GetReports();
        this.ReportItems = reports.ReportItems;
        await base.OnInitializedAsync();
        return;
    }
}


