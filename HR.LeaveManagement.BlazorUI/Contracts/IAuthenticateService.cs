namespace HR.LeaveManagement.BlazorUI.Contracts;

public interface IAuthenticateService
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task LogOut();
    Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password);

}
