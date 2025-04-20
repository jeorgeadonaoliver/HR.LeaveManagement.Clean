using Blazored.LocalStorage;
using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Providers;
using HR.LeaveManagement.BlazorUI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.LeaveManagement.BlazorUI.Services;

public class AuthenticationService : BaseHttpService, IAuthenticateService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    public AuthenticationService(
        IClient client, 
        ILocalStorageService localStorageService,
        AuthenticationStateProvider authenticationStateProvider
        ) : base(client, localStorageService)
    {
        this._authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try 
        {
            AuthRequest authenticationRequest = new AuthRequest()
            {
                Email = email,
                Password = password
            };

            var authenticationResponse = await _client.LoginAsync(authenticationRequest);
            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorageService.SetItemAsync("token", authenticationResponse.Token);

                //set claims in Blazor and login state
                await ((ApiAuthenticationStateProvider)
                    _authenticationStateProvider).LoggedIn();


                return true;
            }

            return false;
        } 
        catch(Exception ex) 
        {
            return false;
        }
    }

    public async Task LogOut()
    {
        await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
    {
        RegistrationRequest registrationRequest = new RegistrationRequest()
        {
            FirstName = firstName,
            LastName = lastName,
            UserName = userName,
            Email = email,
            Password = password
        };

        var response = await _client.RegisterAsync(registrationRequest);

        if (!string.IsNullOrEmpty(response.Id)) 
        {
            return true;
        }

        return false;
    }
}
