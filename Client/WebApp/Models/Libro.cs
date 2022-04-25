using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Libro
    {
        [Required]
        [MaxLength(45)]
        public string Titulo { get; set; }
        [Required]
        public string Sinopsis { get; set; }
        [Required]
        [MaxLength(45)]
        [Display(Name = "Nro. Paginas")]
        public string N_Paginas { get; set; }
        [Display(Name = "Editorial")]
        [Required]
        public int EditorialId { get; set; }
        [Display(Name = "Autores")]
        [Required]
        public List<int> AutoresId { get; set; }
    }
}
