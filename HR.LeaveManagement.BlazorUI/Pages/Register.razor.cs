using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;

namespace HR.LeaveManagement.BlazorUI.Pages
{
    public partial class Register
    {
        public RegisterVM Model { get; set; }

        public string Message { get; set; }

        public NavigationManager NavigationManager { get; set; }    

        [Inject]
        private IAuthenticateService AuthenticationService { get; set; }

        protected override void OnInitialized()
        {
            Model = new RegisterVM();
        }

        public async Task HandleRegister() 
        {
            var result = await AuthenticationService.RegisterAsync(Model.FirstName, 
                Model.LastName, Model.UserName, Model.Email, Model.Password);

            if (result) 
            {
                NavigationManager.NavigateTo("/");
            }
            Message = "Something went wrong, please try again.";
        }
    }
}