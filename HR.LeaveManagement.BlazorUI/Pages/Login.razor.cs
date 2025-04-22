using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models;
using HR.LeaveManagement.BlazorUI.Providers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace HR.LeaveManagement.BlazorUI.Pages
{
    public partial class Login
    {
        public LoginVM Model { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public string Message { get; set; }

        [Inject]
        private IAuthenticateService AuthenticateService { get; set; }

        public Login() { }

        protected override void OnInitialized()
        {
            Model = new LoginVM();
        }
        protected async Task HandleLogin() 
        {
            if (await AuthenticateService.AuthenticateAsync(Model.Email, Model.Password)) 
            {
                NavigationManager.NavigateTo("/home");
            }
            Message = "Username/password combination unknown. "; 
        }
    }
}