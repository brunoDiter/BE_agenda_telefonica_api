﻿using BE_AGENDA_API.DTOs;
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
        
        public bool createContact (ContactForCreationDTO contactDTO)
        {
            Contact contact = new Contact();
            {
                contact.Id = contactDTO.Id;
                contact.Name = contactDTO.Name;
                contact.LastName = contactDTO.LastName;
                contact.CelularNumber = contactDTO.CelularNumber;
                contact.TelephoneNumber = contactDTO.TelephoneNumber;
                contact.Email = contactDTO.Email;
            }
            
            FakeContact.Add(contact);
            return true;
        }
    }   
};