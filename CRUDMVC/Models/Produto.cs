using System.ComponentModel.DataAnnotations;

namespace CRUDMVC.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, 10000, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}