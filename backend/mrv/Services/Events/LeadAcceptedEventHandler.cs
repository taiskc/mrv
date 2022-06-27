using MediatR;
using mrv.Services.Notifications;
namespace mrv.Services.Events
{
    public class LeadAcceptedEventHandler :
                 INotificationHandler<LeadAcceptedNotification>
    {
        public Task Handle(LeadAcceptedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                string path = Directory.GetCurrentDirectory();
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "EmailSent.txt")))
                {
                    outputFile.WriteLine("To: " + LeadAcceptedNotification.Email);
                    outputFile.WriteLine("Message: Lead " + notification.LeadId + " was accepted");
                }
            });
        }
    }
}