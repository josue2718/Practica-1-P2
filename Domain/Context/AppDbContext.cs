using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Practica_1_P2.Domain.Entities;

namespace Practica_1_P2.Domain.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }


    }
}
