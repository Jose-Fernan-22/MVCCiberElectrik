using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("categoria")]
    public class Categoria
    {
        //definimos la clave primaria 
        [Key]
        //definimos el identity
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //definimos la forma de como se mostrara en formularios
        [Display(Name ="Codigo")]
        //Definimos la columna del campo en la tabla
        [Column("codcat")]
        public int codigo { get; set; }

        //definimos el tamaño
        [StringLength(30)]
        //Definimos la forma de como se mostrara en formularios
        [Display(Name ="Nombre")]
        //Definimos que no sea nulo
        [Required]
        //definimos la columna del campo en la tabla
        [Column("nomcat")]
        public string nombre { get; set; }
        //definimos la forma de como se mostrara en formularios
        [Display(Name ="Estado")]
        //definimos qyue no sea nulo
        [Required]
        //definimos la comlumna del campo en la tabla
        [Column("estcat")]
        public bool estado { get; set; }
    }
}