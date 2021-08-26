using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCadastroCliente.Models;

namespace WebCadastroCliente.Contexto
{
    public class CadastroDbContextcs : DbContext
    {
        public CadastroDbContextcs(DbContextOptions<CadastroDbContextcs> options) : base(options)
        {        
        }

        //CRIANDO DBSETs
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Endereco> Endereco { get; set; }      
        
        //DEFININDO PK, FK E RELACIONAMENTOS 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(c =>
            {
                c.HasKey(u => u.ID);

                c.HasOne(u => u.RedesSociais)
                    .WithOne()
                    .OnDelete(DeleteBehavior.Cascade);

                c.HasMany(u => u.Telefones)
                    .WithOne()
                    .HasForeignKey(t => t.ClienteID)
                    .OnDelete(DeleteBehavior.Cascade);

                c.HasMany(u => u.Enderecos)
                    .WithOne()
                    .HasForeignKey(e => e.ClienteID)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<RedeSocial>(e =>
            {
                e.HasKey(m => m.ID);
            });

            modelBuilder.Entity<Telefone>(e =>
            {
                e.HasKey(m => m.ID);
            });

            modelBuilder.Entity<Endereco>(e =>
            {
                e.HasKey(m => m.ID);
            });
        }
    }
}
