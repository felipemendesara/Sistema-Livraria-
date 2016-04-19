using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaMendes.Models
{
    public class Livrarias
    {
        [Key]
        [ScaffoldColumn(false)]
        [Display(Name = "Código da livraria")]
        public int IdLivraria { get; set; }
        [Required]
        [Display(Name = "Nome da Livraria")]
        public string ApelidoLivraria { get; set; }
        [Required]
        [Display(Name = "Rua/Logradouro")]
        public string Logradouro { get; set; }
        [Required]
        [Display(Name = "Numero")]
        public int Numero { get; set; }
        [Required]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
        [Required]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

    }
}
