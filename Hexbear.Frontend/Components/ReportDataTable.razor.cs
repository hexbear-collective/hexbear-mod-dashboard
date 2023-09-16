using Hexbear.Lib.Models;
using Microsoft.AspNetCore.Components;

namespace Hexbear.Frontend.Components;
public partial class ReportDataTable
{
    [Parameter]
    public List<ReportItem> ReportItems { get; set; }
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public string Height { get; set; }
    private string _searchString;
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        return;
    }

    private Func<ReportItem, bool> _quickFilter => x =>
    {
        if (string.IsNullOrWhiteSpace(_searchString))
            return true;
        if ((x?.PosterName ?? "").Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ((x?.CreatorName ?? "").Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ((x?.OriginalText ?? "").Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;
        if ((x?.ResolverName ?? "").Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };
}
