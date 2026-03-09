using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Implementations
{
    public class MessageService : INotificationService
    {
        public string Send(string message)
        {
            return "Message Sent:" +message;
        }
    }
}
