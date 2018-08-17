using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnalisisDBContext.Models
{
    public partial class analisisschemaContext : DbContext
    {
        public analisisschemaContext()
        {
        }

        public analisisschemaContext(DbContextOptions<analisisschemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patologia> Patologia { get; set; }
        public virtual DbSet<RelacionPatologiaAnalisis> RelacionPatologiaAnalisis { get; set; }
        public virtual DbSet<ValoresAnalisis> ValoresAnalisis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;User Id=root;Password=AnalisisAzi_2018;Database=analisisschema");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patologia>(entity =>
            {
                entity.ToTable("patologia");

                entity.Property(e => e.PatologiaId)
                    .HasColumnName("PatologiaID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Descripcion).HasColumnType("varchar(2048)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(255)");

                entity.Property(e => e.Recomendaciones).HasColumnType("varchar(2048)");

                entity.Property(e => e.Riesgos).HasColumnType("varchar(2048)");

                entity.Property(e => e.Tratamiento).HasColumnType("varchar(2048)");
            });

            modelBuilder.Entity<RelacionPatologiaAnalisis>(entity =>
            {
                entity.HasKey(e => e.RelacionId);

                entity.ToTable("relacion_patologia_analisis");

                entity.HasIndex(e => e.ParametroId)
                    .HasName("fk_parametro_id");

                entity.HasIndex(e => e.PatologiaId)
                    .HasName("fk_patologia_id");

                entity.Property(e => e.RelacionId)
                    .HasColumnName("RelacionID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsMin).HasColumnType("bit(1)");

                entity.Property(e => e.ParametroId)
                    .HasColumnName("ParametroID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PatologiaId)
                    .HasColumnName("PatologiaID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Parametro)
                    .WithMany(p => p.RelacionPatologiaAnalisis)
                    .HasForeignKey(d => d.ParametroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("relacion_patologia_analisis_ibfk_2");

                entity.HasOne(d => d.Patologia)
                    .WithMany(p => p.RelacionPatologiaAnalisis)
                    .HasForeignKey(d => d.PatologiaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("relacion_patologia_analisis_ibfk_1");
            });

            modelBuilder.Entity<ValoresAnalisis>(entity =>
            {
                entity.ToTable("valores_analisis");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaxMujer).HasColumnName("Max_Mujer");

                entity.Property(e => e.MaxVaron).HasColumnName("Max_Varon");

                entity.Property(e => e.MinMujer).HasColumnName("Min_Mujer");

                entity.Property(e => e.MinVaron).HasColumnName("Min_Varon");

                entity.Property(e => e.Parametro).HasColumnType("varchar(255)");
            });
        }
    }
}
