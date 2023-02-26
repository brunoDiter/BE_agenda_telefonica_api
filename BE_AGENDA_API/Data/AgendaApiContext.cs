using BE_AGENDA_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BE_AGENDA_API.Data
{
    public class AgendaApiContext : DbContext  /* Siempre hereda del DbContext del entityFrameworkCore*/
    {
        public DbSet<User> Users { get; set; } /*Aca especifico mis entidades que van a hacer tablas */
        public DbSet<Contact> Contacts { get; set; }

        public AgendaApiContext(DbContextOptions<AgendaApiContext> options) : base(options) /* Creo el constructor que llama la a clase padre, invoco una sobrecarga especifica del constructor Padre,en este paso Options */
        {
    
        }

        protected override void OnModelCreating(ModelBuilder modelBuidler) /* Utilizo el modificador override para sobreescribir el metodo de la clase padre */
        {
            User karen = new User()
            {
                Id = 1,
                Name = "Karen",
                LastName = "Lasot",
                Password = "Pa$$w0rd",
                Email = "karenbailapiola@gmail.com",
                UserName = "karenpiola"
            };
            User luis = new User()
            {
                Id = 2,
                Name = "Luis Gonzalez",
                LastName = "Gonzales",
                Password = "lamismadesiempre",
                Email = "elluismidetotoras@gmail.com",
                UserName = "luismitoto"
            };

            Contact jaimitoC = new Contact()
            {
                Id = 1,
                Name = "Jaimito",
                CelularNumber = 341457896,
                Description = "Plomero",
                TelephoneNumber = null,
                Email = "jaimito@gmail.com",
                UserId = karen.Id,
            };

            Contact pepeC = new Contact()
            {
                Id = 2,
                Name = "Pepe",
                CelularNumber = 34156978,
                Description = "Papa",
                TelephoneNumber = 422568,
                Email = "pepe@gmail.com",
                UserId = luis.Id,
            };

            Contact mariaC = new Contact()
            {
                Id = 3,
                Name = "Maria",
                CelularNumber = 011425789,
                Description = "Jefa",
                TelephoneNumber = null,
                Email = "maria@gmail.com",
                UserId = karen.Id,
            };

            modelBuidler.Entity<Contact>().HasData(mariaC, pepeC, jaimitoC); /* Indico la data que lleva cada tabla */
            modelBuidler.Entity<User>().HasData(karen, luis);

            modelBuidler.Entity<User>().HasMany<Contact>(u => u.Contact).WithOne(u => u.User); /* Defino la relacion de las tablas */
            /* Un usuario tiene muchos contactos en Contacts, con un 1 usuario en User */

            base.OnModelCreating(modelBuidler);

        }   
    }
}
