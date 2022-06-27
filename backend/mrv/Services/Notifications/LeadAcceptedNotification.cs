using MediatR;

namespace mrv.Services.Notifications
{
    public class LeadAcceptedNotification : INotification
    {
        public const string Email = "vendas@test.com";
        public int LeadId { get; set; }
    }
}
