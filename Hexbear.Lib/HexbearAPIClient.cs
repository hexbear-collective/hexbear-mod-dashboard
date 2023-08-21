using Hexbear.Lib.Models;
using System.Net.Http.Json;

namespace Hexbear.Lib
{
    public class HexbearAPIClient
    {
        private bool _isClientSide;
        private HttpClient _client;

        public HexbearAPIClient(IHttpClientFactory clientFactory, bool isClientSide = true)
        {
            _isClientSide = isClientSide;
            _client = clientFactory.CreateClient("API");
        }

        public async Task<PostResponse> GetPost(int id)
        {
            try
            {
                if (!_isClientSide)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var response = await _client.GetFromJsonAsync<PostResponse>($"/post/{id}");
                    return response;
                }
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
                if (!_isClientSide)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var response = await _client.GetFromJsonAsync<CommentResponse>($"/comment/{id}");
                    return response;
                }
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
                if (!_isClientSide)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var response = await _client.GetFromJsonAsync<UserResponse>($"/u/{username}");
                    return response;
                }
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
                if (!_isClientSide)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var response = await _client.GetFromJsonAsync<ListUsersResponse>($"/ListUsers");
                    return response;
                }
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
                if (!_isClientSide)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var response = await _client.GetFromJsonAsync<ReportsResponse>($"/ListReports");
                    return response;
                }
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
                if (!_isClientSide)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    var response = await _client.GetFromJsonAsync<LogResponse>($"/ListLogs");
                    return response;
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}