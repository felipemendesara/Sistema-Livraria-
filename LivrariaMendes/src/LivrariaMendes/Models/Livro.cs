using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaMendes.Models
{
    public class Livro
    {
        [Key]
        [ScaffoldColumn(false)]
        public int IdLivro { get; set; }
        [Required]
        public string Titulo { get; set; }
        public int Ano { get; set; }
        [Range(1,500)]
        public decimal Preco { get; set; }
        public string Genero { get; set; }
        [ScaffoldColumn(false)]
        public int IdAutor { get; set; }
        public virtual Autor Autor { get; set; }
    }
}
