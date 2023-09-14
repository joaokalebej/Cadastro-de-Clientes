using CadastroClientes.Helper;
using CadastroClientes.Models;
using CadastroClientes.Repositorio;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientes.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuariorepositorio;
        private readonly ISessao _sessao;
        public LoginController (IUsuarioRepositorio usuarioRepositorio,
                                ISessao sessao)
        {
            _usuariorepositorio = usuarioRepositorio;
            _sessao = sessao;        
        }

        public IActionResult Index()
        {
            //Se estiver logado, redirecionar para a Home.

            if(_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Sair() 
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel loginModel)
        {
            try
            { 
                if (ModelState.IsValid)//Se o estado da minha model for válido.
                {
                    UsuarioModel usuario = _usuariorepositorio.BuscarPorLogin(loginModel.Email);

                    if(usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Password))
                        {
                            _sessao.CriarSessaoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida. Porfavor, tente novamente.";
                    }
                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido. Por favor, tente novamente.";
                }
                return View("Index");
            }
            catch (Exception)  //Se não.
            {
                TempData["MensagemErro"] = $"Usuário e/ou senha inválida. Por favor, tente novamente.";
                return RedirectToAction("Index");
            }   
        }
    
    
    }
}
