using InsightAI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsightAI.Infraestructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets para cada entidade
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EnderecoEmpresa> EnderecosEmpresa { get; set; }
        public DbSet<RamoEmpresa> RamosEmpresa { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<FeedbackEmpresa> FeedbacksEmpresa { get; set; }
        public DbSet<Analise> Analises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Colaboradores)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Feedbacks)
                .WithOne(f => f.Usuario)
                .HasForeignKey(f => f.UsuarioId);

            modelBuilder.Entity<EnderecoEmpresa>()
                .HasMany(e => e.Empresas)
                .WithOne(emp => emp.Endereco)
                .HasForeignKey(emp => emp.EnderecoId);

            modelBuilder.Entity<RamoEmpresa>()
                .HasMany(r => r.Empresas)
                .WithOne(emp => emp.Ramo)
                .HasForeignKey(emp => emp.RamoEmpresaId);

            modelBuilder.Entity<Empresa>()
                .HasMany(emp => emp.Colaboradores)
                .WithOne(c => c.Empresa)
                .HasForeignKey(c => c.EmpresaId);

            modelBuilder.Entity<Empresa>()
                .HasMany(emp => emp.Feedbacks)
                .WithOne(f => f.Empresa)
                .HasForeignKey(f => f.EmpresaId);

            modelBuilder.Entity<FeedbackEmpresa>()
                .HasMany(f => f.Analises)
                .WithOne(a => a.FeedbackEmpresa)
                .HasForeignKey(a => a.FeedbackEmpresaId);
        }
    }

}
