using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Providers;
//using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.LeaveManagement.BlazorUI.Pages
{
    public partial class Index
    {
        [Inject]
        private AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IAuthenticateService AuthenticateService { get; set; }

        protected async override Task OnInitializedAsync() 
        {
            await ((ApiAuthenticationStateProvider)
                AuthenticationStateProvider).GetAuthenticationStateAsync();
        }

        protected void GoToLogin() 
        {
            navigationManager.NavigateTo("/login");
        }

        protected async void LogOut()
        {
            await AuthenticateService.LogOut();
        }
        protected void GoToRegister()
        {
            navigationManager.NavigateTo("register/");
        }

        
    }
}