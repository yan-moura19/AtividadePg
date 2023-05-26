using AtividadePg.Models;
using Microsoft.EntityFrameworkCore;

namespace AtividadePg.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options) { }
    
        public DbSet<Atividade> atividade { get; set; } 
    }
}
