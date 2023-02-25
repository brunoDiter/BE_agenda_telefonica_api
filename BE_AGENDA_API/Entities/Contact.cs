namespace BE_AGENDA_API.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public long CelularNumber { get; set; }
        public long TelephoneNumber { get; set; }
        public string Email { get; set; } 
        public User User { get; set; }


    }
}
