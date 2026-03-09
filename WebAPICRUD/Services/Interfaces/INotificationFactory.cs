namespace WebAPICRUD.Services.Interfaces
{
    public interface INotificationFactory
    {
        INotificationService GetService(string userType);
    }
}
