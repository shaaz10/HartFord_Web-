namespace CrudCustomers.Services.Auth
{
    public interface IAuthService
    {
        Task<(bool Success, string? Token, string? Error)> LoginAsync(string email, string password);
        Task<(bool Success, string? Error)> RegisterAsync(string email, string password, string role);
    }
}