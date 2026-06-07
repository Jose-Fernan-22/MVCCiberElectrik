using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

    }
}