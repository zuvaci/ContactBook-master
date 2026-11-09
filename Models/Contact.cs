using ContactBook.Entities;

namespace ContactBook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<ContactTag> ContactTags { get; set; } = new List<ContactTag>();


    }
}
