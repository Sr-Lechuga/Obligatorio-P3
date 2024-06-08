using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Implementaciones.EntityFramework
{
    public class PapeleriaContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\MsSqlLocalDb;DATABASE=ObligatorioPapeleria;Integrated Security=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //var convertirEmail = new ValueConverter<Email, string>(mail => mail.DireccionEmail, mail => new Email(mail));
            //modelBuilder.Entity<Usuario>().Property(mail => mail.Email).HasConversion(convertirEmail);
            //modelBuilder.Entity<Usuario>().HasIndex(mail => mail.Email).IsUnique();

            var convertirRut = new ValueConverter<RUT, string>(rut => rut.NroRut, rut => new RUT(rut));
            modelBuilder.Entity<Cliente>().Property(rut => rut.RUT.NroRut).HasConversion(convertirRut);
            modelBuilder.Entity<Cliente>().HasIndex(rut => rut.RUT.NroRut).IsUnique();
        }
    }
}
