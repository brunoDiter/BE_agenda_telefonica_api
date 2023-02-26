using BE_AGENDA_API.DTOs;
using BE_AGENDA_API.Entities;

namespace BE_AGENDA_API.Data.Repository
{
    public class UserRepository
    {
        public static List<User> FakeUsers = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email= "bruno@asdas.com",
                Name ="Bruno",
                Password = "contraseñasegura"
            },
            new User()
            {
                Id=2,
                Email= "eli@asdas.com",
                Name ="Eliana",
                Password = "contraseñasegura"
            },
            new User()
            {
                Id=3,
                Email= "perla@asdas.com",
                Name ="Perla",
                Password = "contraseñasegura"
            },
            new User()
            {
                Id=4,
                Email= "sandra@asdas.com",
                Name ="Sandra",
                Password = "contraseñasegura"
            }

        };
        public List<User> GetAllUsers()
        {
            return FakeUsers;
        }

        

        public bool CreateUser(UserForCreationDTO userDTO)
        {
            User user = new User()
            {
                Email = userDTO.Email,
                Name = userDTO.Name,
                Password = userDTO.Password,
                LastName = userDTO.LastName,
                Id = userDTO.Id,
            };

            FakeUsers.Add(user);
            return true;


        }
    }
}
