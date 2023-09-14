using CadastroClientes.Models;

namespace CadastroClientes.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string Email);
        UsuarioModel Editar(UsuarioModel usuario);
        UsuarioModel Adicionar(UsuarioModel usuario);
        void Apagar(UsuarioModel usuario);
        List<UsuarioModel> Lista();
        UsuarioModel Busca(int id);
    }
}
