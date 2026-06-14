using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("empleado")]
    public class Empleado
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codemp")]
        public int codigo { get; set; }

        [StringLength(60)]
        [Display(Name = "Nombre")]
        [Required]
        [Column("nomemp")]
        public string nombre { get; set; }

        [StringLength(60)]
        [Display(Name = "Apellido Paterno")]
        [Required]
        [Column("apepemp")]
        public string apellidopaterno { get; set; }

        [StringLength(60)]
        [Display(Name = "Apellido Materno")]
        [Required]
        [Column("apememp")]
        public string apellidomaterno { get; set; }

        [StringLength(20)]
        [Display(Name = "Documento")]
        [Required]
        [Column("docemp")]
        public string documento { get; set; }

        [StringLength(100)]
        [Display(Name = "Direccion")]
        [Required]
        [Column("diremp")]
        public string direccion { get; set; }

        [StringLength(15)]
        [Display(Name = "Telefono")]
        [Required]
        [Column("telemp")]
        public string telefono { get; set; }

        [StringLength(20)]
        [Display(Name = "Celular")]
        [Required]
        [Column("celemp")]
        public string celular { get; set; }

        [StringLength(60)]
        [Display(Name = "Correo")]
        [Required]
        [Column("coremp")]
        public string correo { get; set; }

        [StringLength(40)]
        [Display(Name = "Usuario")]
        [Required]
        [Column("usuemp")]
        public string usuario { get; set; }

        [StringLength(60)]
        [Display(Name = "Clave")]
        [Required]
        [Column("claemp")]
        public string clave { get; set; }

        [Display(Name = "Estado")]
        [Required]
        [Column("estemp")]
        public bool estado { get; set; }


        //------CLAVES FORANEAS ------

        //Distrito
        [Required]
        [Column("coddis")]
        public int coddis { get; set; }
        [ForeignKey("coddis")]
        [Display(Name = "Distrito")]
        public virtual Distrito distrito { get; set; }

        //Rol
        [Required]
        [Column("codrol")]
        public int codrol { get; set; }
        [ForeignKey("codrol")]
        [Display(Name = "Rol")]
        public virtual Rol rol { get; set; }

        //Tipo Documento
        [Required]
        [Column("codtipd")]
        public int codtipd { get; set; }
        [ForeignKey("codtipd")]
        [Display(Name = "Tipo Documento")]
        public virtual TipoDocumento tipoDocumento { get; set; }

        //Sexo
        [Required]
        [Column("codsex")]
        public int codsex { get; set; }
        [ForeignKey("codsex")]
        [Display(Name = "Sexo")]
        public virtual Sexo sexo { get; set; }
    }
}