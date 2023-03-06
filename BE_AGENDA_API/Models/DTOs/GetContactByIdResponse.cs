namespace BE_AGENDA_API.Models.DTOs
{
    public class GetContactByIdResponse
    {
        
        public string Name { get; set; }
        public string LastName { get; set; }
        public long CelularNumber { get; set; }
        public long? TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

    }
}
