using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models.db
{
    //generamos herencia de DbContext
    public class ApplicationDbContext : DbContext
    {
        //llamamos a la cadena conexion
        public ApplicationDbContext() : base("DefaultConnection") { }

        //por cada modelo generado debemos de realizar un DbSet
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<Marca> marca { get; set; }
        public DbSet<Producto> producto { get; set; }

        // ---------- Nuevas tablas Simples ----------
        public DbSet<Distrito> distrito { get; set; }
        public DbSet<Rol> rol { get; set; }
        public DbSet<TipoDocumento> tipodocumento { get; set; }
        public DbSet<Sexo> sexo { get; set; }

        // ---------- Nuevas tablas Cruzadas ----------

        public DbSet<Empleado> empleado { get; set; }
        public DbSet<Cliente> cliente { get; set; }


    }
}