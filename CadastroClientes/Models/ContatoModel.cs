using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using Xunit;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace CadastroClientes.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato.")]
        public string Nome { get; set; }
        [RequiredAttribute(ErrorMessage = "Digite o e-mail do contato.")]
        [EmailAddress(ErrorMessage = "")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite o celular do contato")]
        public string Celular { get; set; }
    }
}
