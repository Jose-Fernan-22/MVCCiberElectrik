using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codcli")]
        public int codigo { get; set; }

        [StringLength(60)]
        [Display(Name = "Nombre")]
        [Required]
        [Column("nomcli")]
        public string nombre { get; set; }

        [StringLength(60)]
        [Display(Name = "Apellido Paterno")]
        [Required]
        [Column("apepcli")]
        public string apellidopaterno { get; set; }

        [StringLength(60)]
        [Display(Name = "Apellido Materno")]
        [Required]
        [Column("apemcli")]
        public string apellidomaterno { get; set; }

        [StringLength(20)]
        [Display(Name = "Documento")]
        [Required]
        [Column("doccli")]
        public string documento { get; set; }

        [StringLength(100)]
        [Display(Name = "Dirección")]
        [Required]
        [Column("dircli")]
        public string direccion { get; set; }

        [StringLength(7)]
        [Display(Name = "Teléfono")]
        [Required]
        [Column("telcli")]
        public string telefono { get; set; }

        [StringLength(9)]
        [Display(Name = "Celular")]
        [Required]
        [Column("celcli")]
        public string celular { get; set; }

        [StringLength(60)]
        [Display(Name = "Correo")]
        [Required]
        [Column("corcli")]
        public string correo { get; set; }

        [Display(Name = "Estado")]
        [Required]
        [Column("estcli")]
        public bool estado { get; set; }

        // --- CLAVES FORANEAS ---

        //Distrito
        [Required]
        [Column("coddis")]
        public int coddis { get; set; }
        [ForeignKey("coddis")]
        [Display(Name = "Distrito")]
        public virtual Distrito distrito { get; set; }

        // tipo Documento
        [Required]
        [Column("codtipd")]
        public int codtipd { get; set; }
        [ForeignKey("codtipd")]
        [Display(Name = "Tipo Documento")]
        public virtual TipoDocumento tipodocumento { get; set; }

        // sexo
        [Required]
        [Column("codsex")]
        public int codsex { get; set; }
        [ForeignKey("codsex")]
        [Display(Name = "Sexo")]
        public virtual Sexo sexo { get; set; }

    }
}