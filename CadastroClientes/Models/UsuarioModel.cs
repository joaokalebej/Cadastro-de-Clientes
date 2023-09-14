using System;
using CadastroClientes.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CadastroClientes.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [MaxLength(250, ErrorMessage = "O tamanho máximo do campo é de {0} caracteres")]
        [Required]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "O tamanho máximo do campo é {0} caracteres")]

        public string Password { get; set; }

        public PerfilEnum Perfil { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }

        public bool SenhaValida(string senha)
        {
            return Password == senha;
        }
    }

}
