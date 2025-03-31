using Microsoft.EntityFrameworkCore;
using Universidade.Domain;

namespace Universidade.Infra
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Professor> Professores { get; set; }
    }
}