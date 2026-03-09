using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class EmailService:INotificationService
    {
        public string Send(string message)
        {
            return "Email sent: " + message;
        }
    }
}
