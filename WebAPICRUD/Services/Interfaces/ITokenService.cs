namespace WebAPICRUD.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
