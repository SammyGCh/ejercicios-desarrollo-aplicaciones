using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PrimeraWebApp.ModelsDB
{
    public partial class alumnosContext : DbContext
    {
        public alumnosContext()
        {
        }

        public alumnosContext(DbContextOptions<alumnosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }
        public virtual DbSet<Calificacion> Calificacions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;user=root;database=alumnos;port=3306;password=Sammy991001");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.ToTable("alumno");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Domicilio).HasMaxLength(100);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Foto).HasColumnType("longblob");

                entity.Property(e => e.Matricula).HasMaxLength(20);

                entity.Property(e => e.Nombre).HasMaxLength(100);

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsFixedLength(true);

                entity.Property(e => e.Telefono).HasMaxLength(50);
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.ToTable("calificacion");

                entity.HasIndex(e => e.Idalumno, "IDAlumno");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Idalumno)
                    .HasColumnType("int(11)")
                    .HasColumnName("IDAlumno");

                entity.Property(e => e.IdexperienciaEducativa)
                    .HasColumnType("int(255)")
                    .HasColumnName("IDExperienciaEducativa");

                entity.Property(e => e.Oportunidad).HasColumnType("int(255)");

                entity.Property(e => e.Valor).HasColumnType("int(255)");

                entity.HasOne(d => d.IdalumnoNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.Idalumno)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("calificacion_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
