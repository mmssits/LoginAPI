using LoginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { } // inicializa as opções base da super classe

        // Setagem de tabelas
        public DbSet<User> Usuarios { get; set; }
    }
}
