    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaMendes.Models
{
    public class Autor
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "Código")]
        public int IdAutor { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Sobre nome")]
        public string SobreNome { get; set; }
        public virtual ICollection<Livro> Livros { get; set; }


    }
}
