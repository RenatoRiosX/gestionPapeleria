using LogicaNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.RepositorioEF
{
    public class Context:DbContext
    {
        
        
        //Aqui se definen las tablas de la base de datos
        public DbSet<Articulo> Articulos {  get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Configuracion> Configuraciones { get; set; }

        public DbSet<Administrador> Administradores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localDB)\Mssqllocaldb;DATABASE=Papeleria;INTEGRATED SECURITY=True; encrypt=false");
        }

        //Configurar las entidades de la base de datos 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
	        modelBuilder.Entity<Articulo>()
		        .HasIndex(a => new { a.Nombre, a.Codigo })
		        .IsUnique();
            modelBuilder.Entity<Articulo>()
                .HasIndex(a => a.Codigo)
                .IsUnique();

            modelBuilder.Entity<Configuracion>()
	            .HasIndex(p => p.Nombre)
	            .IsUnique();

        }
	}
}

