using MediatR;
using mrv.Context;
using mrv.Models;

namespace mrv.Features.Queries
{
    public class GetLeadByIdQuery : IRequest<Lead>
    {
        public int Id { get; set; }
        public class GetLeadByIdQueryHandler : IRequestHandler<GetLeadByIdQuery, Lead>
        {
            private readonly ILeadRepository _context;
            public GetLeadByIdQueryHandler(ILeadRepository context)
            {
                _context = context;
            }
            public async Task<Lead> Handle(GetLeadByIdQuery query, CancellationToken cancellationToken)
            {
                var lead = _context.Leads.Where(a => a.Id == query.Id).FirstOrDefault();
                if (lead == null) return null;
                return lead;
            }
        }
    }
}
