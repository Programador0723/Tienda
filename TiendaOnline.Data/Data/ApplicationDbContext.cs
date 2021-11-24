using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TiendaOnline.Models.Models;

namespace TiendaOnline.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
