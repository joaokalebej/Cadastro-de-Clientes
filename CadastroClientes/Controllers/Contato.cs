using CadastroClientes.Data;
using CadastroClientes.Models;
using CadastroClientes.Repositorio;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CadastroClientes.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {

            return View(_contatoRepositorio.Lista());
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            //busca os dados do contato
            var buscar = _contatoRepositorio.Busca(id);

            //retorna os dados para a view
            return View(buscar);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            var att = _contatoRepositorio.Busca(id);
            return View(att);
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"OPS! Contato não foi cadastrado com sucesso!, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Editar(contato);
                    TempData["MensagemSucesso"] = "Contato editado com sucesso!";
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"OPS! Contato não foi editado com sucesso!, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult ApagarConfirmacao(ContatoModel contato)
        {
            try
            {
                _contatoRepositorio.Apagar(contato);
                TempData["MensagemSucesso"] = "Contato apagado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"OPS! Contato não  com sucesso!, Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
