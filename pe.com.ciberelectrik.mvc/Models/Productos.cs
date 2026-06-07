using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("producto")]
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codpro")]
        public int codigo { get; set; }

        [StringLength(80)]
        [Display(Name = "Nombre")]
        [Required]
        [Column("nompro")]
        public string nombre { get; set; }
        [StringLength(300)]
        [Display(Name = "Descripcion")]
        [Required]
        [Column("despro")]
        public string descripcion { get; set; }
        [Display(Name = "Precio")]
        [Required]
        [Column("prepro")]
        public decimal precio { get; set; }

        [Display(Name = "Cantidad")]
        [Required]
        [Column("canpro")]
        public int cantidad { get; set; }

        [Display(Name = "Fec. Ingreso")]
        [Required]
        [Column("fecing")]
        public DateTime fechaingreso { get; set; }

        [Display(Name = "Estado")]
        [Required]
        [Column("estpro")]
        public bool estado { get; set; }


        //para claves foraneas
        //Marca
        [Required]
        [Column("codmar")]
        public int codmar { get; set; }
        [ForeignKey("codmar")]
        [Display(Name = "Marca")]
        public virtual Marca marca { get; set; }

        //Categoria
        [Required]
        [Column("codcat")]
        public int codcat { get; set; }
        [ForeignKey("codcat")]
        [Display(Name = "Categoria")]
        public virtual Categoria categoria { get; set; }
    }
}