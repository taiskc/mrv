using MediatR;
using Microsoft.EntityFrameworkCore;
using mrv.Context;
using mrv.Models;

namespace mrv.Features.Queries
{
    public class GetNewLeadsQuery : IRequest<IEnumerable<Lead>>
    {
        public class GetNewLeadsQueryHandler : IRequestHandler<GetNewLeadsQuery, IEnumerable<Lead>>
        {
            private readonly ILeadRepository _context;
            public GetNewLeadsQueryHandler(ILeadRepository context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Lead>> Handle(GetNewLeadsQuery query, CancellationToken cancellationToken)
            {
                var leadList = await _context.Leads.OrderBy(lead => lead.CreatedAt).ToListAsync();
                var newLeadList = leadList.FindAll(lead => lead.Approved is null);
                return newLeadList.AsReadOnly();
            }
        }
    }
}
