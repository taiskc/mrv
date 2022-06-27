using MediatR;
using mrv.Context;
using mrv.Models;

namespace mrv.Features.Commands
{
    public class CreateLeadCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, int>
        {
            private readonly ILeadRepository _context;
            public CreateLeadCommandHandler(ILeadRepository context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateLeadCommand command, CancellationToken cancellationToken)
            {
                var lead = new Lead();
                lead.FirstName = command.FirstName;
                lead.LastName = command.LastName;
                lead.Email = command.Email;
                lead.Phone = command.Phone;
                lead.CreatedAt = DateTime.Now;
                lead.Suburb = command.Suburb;
                lead.Category = command.Category;
                lead.Price = command.Price;
                lead.Description = command.Description;
                _context.Leads.Add(lead);
                await _context.SaveChanges();
                return lead.Id;
            }
        }
    }
}
