using Microsoft.EntityFrameworkCore;

namespace BE_AGENDA_API.Data
{
    public class AgendaApiContext : DbContext  /* Siempre hereda del DbContext del entityFrameworkCore*/
    {
        public DbSet<> /*Aca especifico mis entidades que van a hacer tablas */
    }
}
