using MediatR;
using mrv.Context;
using mrv.Models;
using mrv.Services.Notifications;

namespace mrv.Features.Commands
{
    public class EvaluateLeadCommand : IRequest<int>
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
        public class EvaluateLeadCommandHandler : IRequestHandler<EvaluateLeadCommand, int>
        {
            private readonly ILeadRepository _context;
            private readonly IMediator _mediator;
            public EvaluateLeadCommandHandler(ILeadRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<int> Handle(EvaluateLeadCommand command, CancellationToken cancellationToken)
            {
                var lead = _context.Leads.Where(a => a.Id == command.Id).FirstOrDefault();

                if (lead == null)
                {
                    return default;
                }

                if (command.Approved)
                {
                    ApplyDiscount(lead);
                }

                lead.Approved = command.Approved;
                
                await _context.SaveChanges();
                await _mediator.Publish(new LeadApprovedNotification
                {
                    LeadId = lead.Id
                }, cancellationToken);
                return lead.Id;
            }

            private void ApplyDiscount(Lead lead)
            {
                lead.Price = lead.Price > 500 ? lead.Price * 0.90M : lead.Price;
            }
        }
    }
}
