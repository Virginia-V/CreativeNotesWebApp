using CreativeNotes.Domain;
using Microsoft.EntityFrameworkCore;

namespace CreativeNotes.Dal
{
    public class CreativeNotesDbContext : DbContext
    {
        public CreativeNotesDbContext(DbContextOptions<CreativeNotesDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CreativeNotesDbContext).Assembly);
        }

        public virtual DbSet<Post> Posts { get; set; }
    }
}
