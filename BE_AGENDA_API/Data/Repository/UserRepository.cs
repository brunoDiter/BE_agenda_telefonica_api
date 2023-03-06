using BE_AGENDA_API.Entities;
using BE_AGENDA_API.Models.DTOs;
using static BE_AGENDA_API.Models.DTOs.Enum.States;

namespace BE_AGENDA_API.Data.Repository
{
    public class UserRepository
    {
        private AgendaApiContext _context; /* Inyecto la dependencia del contexto. */
        public UserRepository(AgendaApiContext context)
        {
            _context = context;
        }

        public static List<User> FakeUsers = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email= "bruno@asdas.com",
                Name ="Bruno",
                Password = "contraseñasegura",
                UserName = "bruno"
                
            },
            new User()
            {
                Id=2,
                Email= "eli@asdas.com",
                Name ="Eliana",
                Password = "contraseñasegura",
                UserName = "eliana"
            },
            new User()
            {
                Id=3,
                Email= "perla@asdas.com",
                Name ="Perla",
                Password = "contraseñasegura",
                UserName = "perla"

            },
            new User()
            {
                Id=4,
                Email= "sandra@asdas.com",
                Name ="Sandra",
                Password = "contraseñasegura",
                UserName = "sandra"
            }

        };
        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
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

        public void Delete(int Id)
        {
            _context.Users.Remove(_context.Users.Single(u => u.Id == Id));
        }
        
        public void Archive(int Id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == Id);
            if (user != null)
            {
                user.state = State.Archived;
                _context.Update(user);
            }
        }

        public User? Validate(string User, string Password) /* Metodo para saber si existe el User y la pass es correcta */
        {
            return FakeUsers.FirstOrDefault(x => x.UserName == User && x.Password == Password);
        }
    }
}
