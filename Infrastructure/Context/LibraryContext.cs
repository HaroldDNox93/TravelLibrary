using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() { }
        public LibraryContext(DbContextOptions options) : base(options) { }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<AutorHasLibro> AutoresHasLibros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("autores");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
                entity.Property(e => e.Apellidos)
                    .HasMaxLength(45)
                    .HasColumnName("apellidos");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.ToTable("editoriales");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(45)
                    .HasColumnName("nombre");
                entity.Property(e => e.Sede)
                    .HasMaxLength(45)
                    .HasColumnName("sede");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.Isbn);
                entity.ToTable("libros");
                entity.Property(e => e.Isbn).HasColumnName("ISBN");
                entity.Property(e => e.EditorialId).HasColumnName("editorial_id");
                entity.Property(e => e.N_Paginas)
                    .HasMaxLength(45)
                    .HasColumnName("n_paginas");
                entity.Property(e => e.Sinopsis)
                    .HasColumnType("text")
                    .HasColumnName("sinopsis");
                entity.Property(e => e.Titulo)
                    .HasMaxLength(45)
                    .HasColumnName("titulo");
            });

            modelBuilder.Entity<AutorHasLibro>(entity =>
            {
                entity.HasKey(e => new { e.Autor_Id, e.Libro_Isbn });
                entity.ToTable("autores_has_libros");
                entity.Property(e => e.Autor_Id).HasColumnName("autor_id");
                entity.Property(e => e.Libro_Isbn).HasColumnName("libro_ISBN");
                entity.HasOne(d => d.Autor)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.Autor_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Libro)
                    .WithMany(p => p.AutoresHasLibros)
                    .HasForeignKey(d => d.Libro_Isbn)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
    }
}
