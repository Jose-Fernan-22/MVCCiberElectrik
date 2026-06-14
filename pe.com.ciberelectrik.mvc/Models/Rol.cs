using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace pe.com.ciberelectrik.mvc.Models
{
    [Table("rol")]

    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Codigo")]
        [Column("codrol")]
        public int codigo { get; set; }

        [StringLength(40)]
        [Display(Name = "Nombre")]
        [Required]
        [Column("nomrol")]
        public string nombre { get; set; }

        [Display(Name = "Estado")]
        [Required]
        [Column("estrol")]
        public bool estado { get; set; }

    }
}