using Hexbear.Lib.EFCore;
using Hexbear.Lib.Models;
using Hexbear.Lib.Services;
using System.Net.Http.Json;

namespace Hexbear.Lib
{
    public class HexbearAPIClient
    {
        private HttpClient _client;
        private LemmyContext _dbContext;
        private bool IsServer { get { return _client == null; } }
        private UserService _userService = new UserService();
        private PostService _postService = new PostService();
        private ReportService _reportService = new ReportService();

        public HexbearAPIClient(IHttpClientFactory clientFactory = null, LemmyContext dbContext = null)
        {
            if (clientFactory != null)
            {
                _client = clientFactory.CreateClient("API");
            }
            _dbContext = dbContext;
        }

        public async Task<PostResponse> GetPost(int id)
        {
            try
            {
                if (IsServer)
                    return await _postService.GetPostDetails(id, _dbContext);
                else 
                    return await _client.GetFromJsonAsync<PostResponse>($"/api/post/{id}");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<CommentResponse> GetComment(int id)
        {
            try
            {
                if (IsServer)
                    return await _postService.GetCommentDetails(id, _dbContext);
                else
                    return await _client.GetFromJsonAsync<CommentResponse>($"/api/comment/{id}");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<UserResponse> GetUser(string username)
        {
            try
            {
                if (IsServer)
                    return await _userService.GetUserByName(_dbContext, username);
                else
                    return await _client.GetFromJsonAsync<UserResponse>($"/api/u/{username}");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<ListUsersResponse> ListUsers()
        {
            try
            {
                if (IsServer)
                    return await _userService.ListUsers(_dbContext);
                else
                    return await _client.GetFromJsonAsync<ListUsersResponse>($"/api/ListUsers");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<ReportsResponse> GetReports()
        {
            try
            {
                if (IsServer)
                    return await _reportService.ListReports(_dbContext);
                else
                    return await _client.GetFromJsonAsync<ReportsResponse>($"/api/ListReports");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<LogResponse> ListLogs()
        {
            try
            {
                if (IsServer)
                    return new LogResponse();
                return await _client.GetFromJsonAsync<LogResponse>($"/api/ListLogs");
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}