using Dance_MVCRepository.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gen2_MVCRepository.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.Entity(typeof(Incripciones))
                .HasOne(typeof(Aprendices), "AprObj")
                .WithMany()
                .HasForeignKey("Aprendices_Id")
                .OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity(typeof(Incripciones))
                .HasOne(typeof(Instructores), "InsObj")
                .WithMany()
                .HasForeignKey("Instructor_Id")
                .OnDelete(DeleteBehavior.Restrict); // no ON DELETE
            modelbuilder.Entity(typeof(Incripciones))
                .HasOne(typeof(Direccion), "DirObj")
                .WithMany()
                .HasForeignKey("Direccion_Id")
                .OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity(typeof(Incripciones))
                .HasOne(typeof(Genero), "GenObj")
                .WithMany()
                .HasForeignKey("Genero_Id")
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Instructores> Instructores { get; set; }
        public DbSet<Aprendices> Aprendices { get; set; }
        public DbSet<Direccion> Direccion { get; set; }

        public DbSet<Incripciones> Incripciones { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
