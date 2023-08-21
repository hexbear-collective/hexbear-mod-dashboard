using Hexbear.Lib.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Cryptography;

namespace Hexbear.Frontend.Pages;
public partial class PostDetails
{
    [Parameter]
    public int Id { get; set; }
    private int _id;
    public Post Post { get; set; }
    protected override async Task OnInitializedAsync()
    {
        _id = Id;
        var res = await _client.GetPost(Id);
        this.Post = res.Post;
        await base.OnInitializedAsync();
        return;
    }
    protected override async Task OnParametersSetAsync()
    {
        if (_id == Id)
            return;
        this.Post = null;
        await OnInitializedAsync();
    }

}
