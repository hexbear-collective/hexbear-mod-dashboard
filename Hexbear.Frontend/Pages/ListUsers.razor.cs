using Hexbear.Lib.Models;
using Microsoft.AspNetCore.Components;

namespace Hexbear.Frontend.Pages;
public partial class ListUsers
{
    public List<string> Users { get; set; }
    private string _searchString;
    protected override async Task OnInitializedAsync()
    {
        this.Users = (await _client.ListUsers()).Users;
        await base.OnInitializedAsync();
        return;
    }

    private Func<string, bool> _quickFilter => x =>
    {
        if (string.IsNullOrWhiteSpace(_searchString))
            return true;
        if (x.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
            return true;

        return false;
    };
}
