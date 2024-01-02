using Hexbear.Lib.EFCore;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Caching.Memory;
using Radzen;
using Radzen.Blazor;

namespace hexbear_dashboard.Client.Components.Pages;
public partial class ListUsers
{
    public string SearchText { get; set; } = "";
    public bool IsLoading { get; set; }
    public List<string> Users { get; set; } = new List<string>();
    public List<string> FilteredUsers { get; set; } = new List<string>();
    public int Count { get; set; }
    public int PerPage { get; set; } = 25;

    public async Task LoadData(LoadDataArgs args)
    {
        IsLoading = true;
        this.Users = (await _client.ListUsers()).Users;
        this.FilterUsers();
        _cache.Set("Users", this.Users);
        IsLoading = false;
    }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        var hasCachedData = _cache.TryGetValue<List<string>>("Users", out var users);
        if (hasCachedData)
        {
            this.Users = users;
            FilterUsers();
        }
        else
        {
            await this.LoadData(new LoadDataArgs() { });
        }
    }

    protected void OnSearchChange(string s)
    {
        SearchText = s;
        FilterUsers();
    }

    protected void FilterUsers()
    {
        this.FilteredUsers = this.Users.Where(x =>
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;
            if (x.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                return true;

            return false;

        }).OrderBy(x => x,StringComparer.OrdinalIgnoreCase).ToList();
    }
}
