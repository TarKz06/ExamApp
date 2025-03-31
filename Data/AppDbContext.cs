using ExamManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamManager.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Exam> Exams { get; set; }
        public DbSet<Choice> Choices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Choice>()
                .HasOne(c => c.Exam)
                .WithMany(e => e.Choices)
                .HasForeignKey(c => c.ExamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Exam>()
                .HasOne(e => e.SelectedChoice)
                .WithMany()
                .HasForeignKey(e => e.SelectedChoiceId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
