using System.ComponentModel.DataAnnotations;

namespace mrv.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email {get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Suburb { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool? Accepted { get; set; }
    }
}
