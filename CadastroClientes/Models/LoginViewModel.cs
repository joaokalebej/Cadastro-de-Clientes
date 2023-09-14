using CadastroClientes.Enums;
using System.ComponentModel.DataAnnotations;

namespace CadastroClientes.Models
{
    public class LoginViewModel
    {
        [MaxLength(250, ErrorMessage = "O tamanho máximo do campo é de {0} caracteres")]
        [Required]

        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "O tamanho máximo do campo é {0} caracteres")]
        public string Password { get; set; }

    }
}
