using Blazored.LocalStorage;
using System.Net.Http.Headers;

namespace HR.LeaveManagement.BlazorUI.Services.Base;

public class BaseHttpService
{
    protected IClient _client;
    public ILocalStorageService _localStorageService { get; }

    public BaseHttpService(IClient client, ILocalStorageService localStorageService)
    {
        _client = client;
        _localStorageService = localStorageService;
    }

    protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
    {
        if (ex.StatusCode == 400) {

            return new Response<Guid>()
            {
                Message = "Invalid data was submitted",
                ValidationErrors = ex.Response, Success = false
            };
        }
        else if (ex.StatusCode == 404)
        {

            return new Response<Guid>()
            {
                Message = "The Record was not found. ",
                ValidationErrors = ex.Response,
                Success = false
            };
        }
        else
        {

            return new Response<Guid>()
            {
                Message = "Something went wrong. Please try again later.",
                ValidationErrors = ex.Response,
                Success = false
            };
        }
    }

    protected async Task AddBearerToken() 
    {
        if (await _localStorageService.ContainKeyAsync("token"))
            _client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", await
                _localStorageService.GetItemAsync<string>("token"));
    }
}
