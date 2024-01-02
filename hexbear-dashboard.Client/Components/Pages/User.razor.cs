using Hexbear.Lib.EFCore;
using Hexbear.Lib.Models;
using Microsoft.AspNetCore.Components;

namespace hexbear_dashboard.Client.Components.Pages;
public partial class User
{
    [Parameter]
    public string Username { get; set; }
    private string _localUsername;

    public Person Person { get; private set; }
    public List<ReportItem> ReportedItems { get; private set; }
    public List<ReportItem> ReportsCreatedItems { get; private set; }
    public List<Comment> UpvotedRemovedComments { get; private set; }
    public List<Post> UpvotedRemovedPosts { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        _localUsername = Username;
        await base.OnInitializedAsync();
        var res = await _client.GetUser(this.Username);
        this.Person = res.Person;
        this.ReportedItems = res.ReportedItems;
        this.ReportsCreatedItems = res.ReportsCreatedItems;
        this.UpvotedRemovedComments = res.UpvotedRemovedComments;
        this.UpvotedRemovedPosts = res.UpvotedRemovedPosts;
        return;
    }

    protected override async Task OnParametersSetAsync()
    {
        if (_localUsername == Username)
            return;
        this.Person = null;
        await OnInitializedAsync();
    }

    protected string GetAgainstCount()
    {
        return $"Comments: {this.ReportedItems.Where(x => x.ReportType == "Comment").Count()}, Post: {this.ReportedItems.Where(x => x.ReportType == "Post").Count()}, DMs {this.ReportedItems.Where(x => x.ReportType == "Private Message").Count()}";
    }

    protected string GetCreatedCount()
    {
        return $"Comments: {this.ReportsCreatedItems.Where(x => x.ReportType == "Comment").Count()}, Post: {this.ReportsCreatedItems.Where(x => x.ReportType == "Post").Count()}, DMs {this.ReportsCreatedItems.Where(x => x.ReportType == "Private Message").Count()}";
    }
}
