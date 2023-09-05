using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class AlunoModel
    {
        // modelo do banco de dados

        public int Id { get; set; }
        [Required(ErrorMessage ="Digite seu nome")]
        public string Name { get; set; }
		[Required(ErrorMessage = "Digite seu telefone")]
		public string telefone { get; set; }
		[Required(ErrorMessage = "Digite seu CPF")]
		public string CPF { get; set; }
		[Required(ErrorMessage = "Digite seu email")]
		public string email { get; set; }
    }
}
