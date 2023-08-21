using Hexbear.Lib.Models;
using Microsoft.AspNetCore.Components;

namespace Hexbear.Frontend.Pages;
public partial class CommentDetails
{
    [Parameter]
    public int Id { get; set; }
    private int _id;
    public Comment Comment { get; set; }
    protected override async Task OnInitializedAsync()
    {
        _id = Id;
        var res = await _client.GetComment(Id);
        this.Comment = res.Comment;
        await base.OnInitializedAsync();
        return;
    }
    protected override async Task OnParametersSetAsync()
    {
        if (_id == Id)
            return;
        this.Comment = null;
        await OnInitializedAsync();
    }
}
