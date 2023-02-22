using BE_AGENDA_API.Entities;

namespace BE_AGENDA_API.Repository
{
    public class ContactRepository
    {
        public static List<Contact> FakeContact = new List<Contact>()
        {
            new Contact()
            {
                Id = 1,
                Name = "HAISDA",
                LastName = "ASDA",
                CelularNumber = 3412799201,
                TelephoneNumber = 4610399,
                Email = "asdas@asd.com",
                birthday = "21/09/1990"
            },
            new Contact()
            {
                Id = 2,
                Name = "HAISDA",
                LastName = "ASDA",
                CelularNumber = 3412799201,
                TelephoneNumber = 4610399,
                Email = "asdas@asd.com",
                birthday = "21/09/1990"
            },
            new Contact()
            {
                Id = 3,
                Name = "HAISDA",
                LastName = "ASDA",
                CelularNumber = 3412799201,
                TelephoneNumber = 4610399,
                Email = "asdas@asd.com",
                birthday = "21/09/1990"
            },
            new Contact()
            {
                Id = 4,
                Name = "HAISDA",
                LastName = "ASDA",
                CelularNumber = 3412799201,
                TelephoneNumber = 4610399,
                Email = "asdas@asd.com",
                birthday = "21/09/1990"
            }
        };

        public List<Contact> GetAllContacts()
        {
            return FakeContact;
        }
    }
};