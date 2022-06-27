using MediatR;
using mrv.Context;
using mrv.Models;
using mrv.Services.Notifications;

namespace mrv.Features.Commands
{
    public class EvaluateLeadCommand : IRequest<Lead>
    {
        public int Id { get; set; }
        public bool Accepted { get; set; }
        public class EvaluateLeadCommandHandler : IRequestHandler<EvaluateLeadCommand, Lead>
        {
            private readonly ILeadRepository _context;
            private readonly IMediator _mediator;
            public EvaluateLeadCommandHandler(ILeadRepository context, IMediator mediator)
            {
                _context = context;
                _mediator = mediator;
            }
            public async Task<Lead> Handle(EvaluateLeadCommand command, CancellationToken cancellationToken)
            {
                var lead = _context.Leads.Where(a => a.Id == command.Id).FirstOrDefault();

                if (lead == null)
                {
                    throw new KeyNotFoundException("Lead not found!");
                }

                if (lead.Accepted is true)
                {
                    throw new Exception("Lead already accepted!");
                }

                if (lead.Accepted is false)
                {
                    throw new Exception("Lead already declined!");
                }

                if (command.Accepted)
                {
                    ApplyDiscount(lead);
                }

                lead.Accepted = command.Accepted;
                
                await _context.SaveChanges();
                await _mediator.Publish(new LeadAcceptedNotification
                {
                    LeadId = lead.Id
                }, cancellationToken);
                return lead;
            }

            private void ApplyDiscount(Lead lead)
            {
                lead.Price = lead.Price > 500 ? lead.Price * 0.90M : lead.Price;
            }
        }
    }
}
