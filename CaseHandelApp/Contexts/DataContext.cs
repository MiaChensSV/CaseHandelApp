using CaseHandelApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CaseHandelApp.Contexts
{
    internal class DataContext:DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\yihon\source\repos\CaseHandelApp\CaseHandelApp\Contexts\case_handel_local_db.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasIndex(x => x.Email)
                .IsUnique();
        }

        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<CaseEntity> Cases { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }
        public DbSet<StatusEntity> Status { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserTypeEntity> UsersType { get; set; }
    }
}
