using CadastroClientes.Models;

namespace CadastroClientes.Helper
{
    public interface ISessao
    {
        void CriarSessaoUsuario(UsuarioModel usuario);
        void RemoverSessaoUsuario();

        UsuarioModel BuscarSessaoUsuario();
    
    }
}
