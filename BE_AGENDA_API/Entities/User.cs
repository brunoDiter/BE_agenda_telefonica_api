namespace BE_AGENDA_API.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }

        public ICollection<Contact>? Contact { get; set; }
    }
}
