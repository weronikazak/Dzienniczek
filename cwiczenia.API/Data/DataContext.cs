using cwiczenia.API.Models;
using Microsoft.EntityFrameworkCore;

namespace cwiczenia.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(s => s.ClassId);

            modelBuilder.Entity<Enrollments>()
                .HasKey(bc => new { bc.StudentId, bc.SubjectId });

            modelBuilder.Entity<Enrollments>()
                .HasOne(s => s.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(s => s.StudentId);

            modelBuilder.Entity<Enrollments>()
                .HasOne(s => s.Subject)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(s => s.SubjectId);  
        }
    }
}