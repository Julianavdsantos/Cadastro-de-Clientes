using Microsoft.EntityFrameworkCore;

namespace Teste_Emccamp.Models
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options) 
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
