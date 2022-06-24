using MediatR;
using mrv.Context;

namespace mrv.Features.Commands
{
    public class UpdateLeadCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Suburb { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public class UpdateLeadCommandHandler : IRequestHandler<UpdateLeadCommand, int>
        {
            private readonly ILeadRepository _context;
            public UpdateLeadCommandHandler(ILeadRepository context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateLeadCommand command, CancellationToken cancellationToken)
            {
                var lead = _context.Leads.Where(a => a.Id == command.Id).FirstOrDefault();

                if (lead == null)
                {
                    return default;
                }
                else
                {
                    lead.FirstName = command.FirstName is null ? lead.FirstName : command.FirstName;
                    lead.LastName = command.LastName is null ? lead.LastName : command.LastName;
                    lead.Email = command.Email is null ? lead.Email : command.Email;
                    lead.Phone = command.Phone is null ? lead.Phone : command.Phone;
                    lead.Suburb = command.Suburb is null ? lead.Suburb : command.Suburb;
                    lead.Category = command.Category is null ? lead.Category : command.Category;
                    lead.Price = command.Price is null ? lead.Price : (decimal)command.Price;
                    lead.Description = command.Description is null ? lead.Description : command.Description;
                    await _context.SaveChanges();
                    return lead.Id;
                }
            }
        }
    }
}
