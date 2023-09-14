using CadastroClientes.Models;
using Newtonsoft.Json;

namespace CadastroClientes.Helper
{
    public class Sessao : ISessao
    {

        private readonly HttpContext _httpContext;

        public Sessao(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext.HttpContext;
        }
        public UsuarioModel BuscarSessaoUsuario()
        {
            string sessaoUsuario = _httpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(UsuarioModel usuario) 
        {
            //SetString recebe duas chaves string, o nome da chave e o valor. porém o valor usuário é um objeto.
            //Então, transformo o objeto em json, tornando-se uma string. depois tenho que converte-la denovo pra objeto (usuario)
            string valor = JsonConvert.SerializeObject(usuario);
            _httpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _httpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
