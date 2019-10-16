using cwiczenia.API.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Student> Students { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        // public DbSet<SetGradeTo> GradeSets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.Class)
                .WithOne(t => t.Teacher)
                .HasForeignKey<Class>(t => t.TeacherId);

            modelBuilder.Entity<Class>()
                .HasOne(t => t.Teacher)
                .WithOne(t => t.Class)
                .HasForeignKey<Teacher>(t => t.ClassId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(s => s.Students)
                .HasForeignKey(c => c.ClassId);
                 
                    
        }
    }
}