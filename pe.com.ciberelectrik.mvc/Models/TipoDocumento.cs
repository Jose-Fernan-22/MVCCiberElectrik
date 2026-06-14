using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("tipodocumento")]
    public class TipoDocumento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codtipd")]
        public int codigo { get; set; }

        [StringLength(40)]
        [Display(Name = "Nombre")]
        [Required]
        [Column("nomtipd")]
        public string nombre { get; set; }

        [Display(Name = "Estado")]
        [Required]
        [Column("esttipd")]
        public bool estado { get; set; }
    }
    
}