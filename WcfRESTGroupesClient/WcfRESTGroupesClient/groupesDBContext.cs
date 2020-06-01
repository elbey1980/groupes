using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WcfRESTGroupesClient
{
    public partial class groupesDBContext : DbContext
    {
        public groupesDBContext()
        {
        }

        public groupesDBContext(DbContextOptions<groupesDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activite> Activite { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=groupesDB");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activite>(entity =>
            {
                entity.HasKey(e => e.NomActivite);

                entity.ToTable("activite");

                entity.Property(e => e.NomActivite)
                    .HasColumnName("nomActivite")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.NomAdmin)
                    .IsRequired()
                    .HasColumnName("nomAdmin")
                    .HasMaxLength(50);
            });
        }
    }
}
