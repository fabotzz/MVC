using System.ComponentModel.DataAnnotations;

namespace CrudSimples.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preço é obrigatório")]
        [Range(0.01, 10000, ErrorMessage = "Preço deve ser entre 0,01 e 10.000")]
        public decimal Preco { get; set; }

        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}