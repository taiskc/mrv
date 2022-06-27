using MediatR;
using Microsoft.EntityFrameworkCore;
using mrv.Context;
using mrv.Models;

namespace mrv.Features.Queries
{
    public class GetAllLeadsQuery : IRequest<IEnumerable<Lead>>
    {
        public class GetAllLeadsQueryHandler : IRequestHandler<GetAllLeadsQuery, IEnumerable<Lead>>
        {
            private readonly ILeadRepository _context;
            public GetAllLeadsQueryHandler(ILeadRepository context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Lead>> Handle(GetAllLeadsQuery query, CancellationToken cancellationToken)
            {
                var leadList = await _context.Leads.OrderBy(lead => lead.CreatedAt).ToListAsync();
                if (leadList == null)
                {
                    return null;
                }
                return leadList.AsReadOnly();
            }
        }
    }
}
