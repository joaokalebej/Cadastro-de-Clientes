using CadastroClientes.Models;

namespace CadastroClientes.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel Editar(ContatoModel contato);
        ContatoModel Adicionar(ContatoModel contato);
        void Apagar(ContatoModel cotato);
        List<ContatoModel> Lista();
        ContatoModel Busca(int id);
    }
}
