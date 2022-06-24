using MediatR;
using Microsoft.EntityFrameworkCore;
using mrv.Context;

namespace mrv.Features.Commands
{
    public class DeleteLeadCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteLeadCommandHandler : IRequestHandler<DeleteLeadCommand, int>
        {
            private readonly ILeadRepository _context;
            public DeleteLeadCommandHandler(ILeadRepository context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteLeadCommand command, CancellationToken cancellationToken)
            {
                var lead = await _context.Leads.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (lead == null) return default;
                _context.Leads.Remove(lead);
                await _context.SaveChanges();
                return lead.Id;
            }
        }
    }
}
