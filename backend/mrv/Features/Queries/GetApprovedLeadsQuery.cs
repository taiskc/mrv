using MediatR;
using Microsoft.EntityFrameworkCore;
using mrv.Context;
using mrv.Models;

namespace mrv.Features.Queries
{
    public class GetApprovedLeadsQuery : IRequest<IEnumerable<Lead>>
    {
        public class GetApprovedLeadsQueryHandler : IRequestHandler<GetApprovedLeadsQuery, IEnumerable<Lead>>
        {
            private readonly ILeadRepository _context;
            public GetApprovedLeadsQueryHandler(ILeadRepository context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Lead>> Handle(GetApprovedLeadsQuery query, CancellationToken cancellationToken)
            {
                var leadList = await _context.Leads.OrderBy(lead => lead.CreatedAt).ToListAsync();
                var newLeadList = leadList.FindAll(lead => lead.Approved is true);
                return newLeadList.AsReadOnly();
            }
        }
    }
}
