using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("distrito")]
    public class Distrito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("coddis")]
        public int codigo { get; set; }

        [StringLength(40)]
        [Display(Name = "Nombre")]
        [Required]
        [Column("nomdis")]
        public string nombre { get; set; }

        [Display(Name = "Estado")]
        [Required]
        [Column("estdis")]
        public bool estado { get; set; }
        
    }
}