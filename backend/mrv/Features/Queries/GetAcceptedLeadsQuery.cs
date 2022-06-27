using MediatR;
using Microsoft.EntityFrameworkCore;
using mrv.Context;
using mrv.Models;

namespace mrv.Features.Queries
{
    public class GetAcceptedLeadsQuery : IRequest<IEnumerable<Lead>>
    {
        public class GetAcceptedLeadsQueryHandler : IRequestHandler<GetAcceptedLeadsQuery, IEnumerable<Lead>>
        {
            private readonly ILeadRepository _context;
            public GetAcceptedLeadsQueryHandler(ILeadRepository context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Lead>> Handle(GetAcceptedLeadsQuery query, CancellationToken cancellationToken)
            {
                var leadList = await _context.Leads.OrderBy(lead => lead.CreatedAt).ToListAsync();
                var newLeadList = leadList.FindAll(lead => lead.Accepted is true);
                return newLeadList.AsReadOnly();
            }
        }
    }
}
