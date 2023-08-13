using Hexbear.Lib.Models;
using MudBlazor;

namespace Hexbear.Frontend.Pages;
public partial class Logs
{
    public List<DockerLog> DockerLogs { get; set; }
    public List<DockerLog> FilteredDockerLogs {
        get
        {
            if (_selectedSource == null)
                return this.DockerLogs;
            else
                return this.DockerLogs.Where(x => x.container == _selectedSource.Text).ToList();
        }
    }
    private List<string> Sources { get; set; }
    private string _searchString;
    private MudChip _selectedSource;
    protected override async Task OnInitializedAsync()
    {
        var reports = await _client.ListLogs();
        this.DockerLogs = reports.Logs;
        this.Sources = this.DockerLogs.Select(y => y.container).Distinct().OrderBy(x => x).ToList();
        await base.OnInitializedAsync();
        return;
    }
    private Func<DockerLog, bool> _quickFilter => x =>
    {
        if (string.IsNullOrWhiteSpace(_searchString))
            return true;
        if (x.container.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (x.log.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if (x.stream.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };
}
