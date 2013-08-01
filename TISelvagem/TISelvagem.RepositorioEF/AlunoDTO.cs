using System;
using System.ComponentModel.DataAnnotations;


namespace TISelvagem.RepositorioEF
{
    public class AlunoDTO
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Mae { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
