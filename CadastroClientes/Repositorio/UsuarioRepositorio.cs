using CadastroClientes.Data;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;

namespace CadastroClientes.Repositorio
{
    public class usuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public usuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public UsuarioModel BuscarPorLogin(string Email)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email == Email);
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            //adicionar no banco de dados.
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Busca(int id)
        {
            var usuario = _bancoContext.Usuarios.Where(i => i.Id == id).FirstOrDefault();
            return usuario;
        }

        public UsuarioModel Editar(UsuarioModel usuario)
        {
            usuario.DataAtualizacao = DateTime.Now;
            _bancoContext.Usuarios.Update(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
        public void Apagar(UsuarioModel usuario)
        {
            _bancoContext.Usuarios.Remove(usuario);
            _bancoContext.SaveChanges();
        }
        public List<UsuarioModel> Lista()
        {
            var lista = _bancoContext.Usuarios.ToList();
            return lista;
        }
    }
}
