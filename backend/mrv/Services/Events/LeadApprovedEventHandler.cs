using MediatR;
using mrv.Services.Notifications;
namespace mrv.Services.Events
{
    public class LeadApprovedEventHandler :
                 INotificationHandler<LeadApprovedNotification>
    {
        public Task Handle(LeadApprovedNotification notification, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                string path = Directory.GetCurrentDirectory();
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(path, "EmailSent.txt")))
                {
                    outputFile.WriteLine("To: " + LeadApprovedNotification.Email);
                    outputFile.WriteLine("Message: Lead " + notification.LeadId + " was accepted");
                }
            });
        }
    }
}