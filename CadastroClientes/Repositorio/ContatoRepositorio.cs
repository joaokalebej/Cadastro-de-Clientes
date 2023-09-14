using CadastroClientes.Data;
using CadastroClientes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CadastroClientes.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {


        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;    
        }
        
        
        public ContatoModel Adicionar(ContatoModel contato)
        {
            //adicionar no banco de dados.

            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Busca(int id)
        {
            var contato = _bancoContext.Contatos.Where(i => i.Id == id).FirstOrDefault();
            return contato;
        }

        public ContatoModel Editar(ContatoModel contato)
        {
            _bancoContext.Contatos.Update (contato);
            _bancoContext.SaveChanges();
            return contato;
        }
        public void Apagar(ContatoModel contato)
        {
            _bancoContext.Contatos.Remove(contato);
            _bancoContext.SaveChanges();
        }
        public List<ContatoModel> Lista()
        {
            var lista = _bancoContext.Contatos.ToList();
            return lista;
        }

    }
}
