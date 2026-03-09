using WebAPICRUD.Services.Implementations;
using WebAPICRUD.Services.Interfaces;

namespace WebAPICRUD.Services.Factories
{
    public class NotificationFactory : INotificationFactory
    {
        private readonly EmailService _emailService;
        private readonly MessageService _messageService;

        public NotificationFactory(EmailService emailService, MessageService messageService )
        {
            _emailService = emailService;
            _messageService = messageService;
        }

        public INotificationService GetService(string userType)
        {
            return userType=="VIP"
                ? _messageService
                : _emailService;
        }
    }
}
