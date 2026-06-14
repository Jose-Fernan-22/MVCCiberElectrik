using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("Sexo")]
    public class Sexo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codsex")]
        public int codigo { get; set; }

        [StringLength(40)]
        [Display(Name = "Nombre")]
        [Required]
        [Column("nomsex")]
        public string nombre { get; set; }

        [Display(Name = "Estado")]
        [Required]
        [Column("estsex")]
        public bool estado { get; set; }
    }
}