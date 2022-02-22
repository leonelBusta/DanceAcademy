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
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Instructores> Instructores { get; set; }
        public DbSet<Aprendices> Aprendices { get; set; }
        public DbSet<Direccion> Direccion { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
