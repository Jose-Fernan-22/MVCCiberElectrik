using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("marca")]
    public class Marca
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codmar")]
        public int codigo { get; set; }

        [StringLength(30)]
        [Display(Name = "Nombre")]
        [Required]
        [Column("nommar")]
        public string nombre { get; set; }
        
        [Display(Name = "Estado")]
        [Required]
        [Column("estmar")]
        public bool estado { get; set; }
    }
}