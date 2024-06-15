using Microsoft.EntityFrameworkCore;
using GymManagementSystem.Models;

namespace GymManagementSystem.Data
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ClassMember> ClassMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassMember>()
                .HasKey(cm => new { cm.ClassId, cm.MemberId });

            modelBuilder.Entity<ClassMember>()
                .HasOne(cm => cm.Class)
                .WithMany(c => c.ClassMembers)
                .HasForeignKey(cm => cm.ClassId);

            modelBuilder.Entity<ClassMember>()
                .HasOne(cm => cm.Member)
                .WithMany(m => m.ClassMembers)
                .HasForeignKey(cm => cm.MemberId);
        }
    }
}
