using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroClientes.Data;
using CadastroClientes.Models;
using CadastroClientes.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CadastroClientes.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepositorio _usuariorepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuariorepositorio = usuarioRepositorio;
        }

        // GET: Usuario
        public IActionResult Index()
        {
            var lista = _usuariorepositorio.Lista();
            return View(lista);
        }

        // GET: 
        public IActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var usuarioModel = _usuariorepositorio.Busca(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }

        // GET:
        public IActionResult Create()
        {
            return View(new UsuarioModel());
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioModel usuarioModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuariorepositorio.Adicionar(usuarioModel);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction(nameof(Index));
                }

            } catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"OPS! Usuário não foi cadastrado com sucesso!, Detalhe do erro: {erro.Message}";
            }
            return View(usuarioModel);
        }

        // GET:
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var usuarioModel = _usuariorepositorio.Busca(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }
            return View(usuarioModel);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UsuarioModel usuarioModel)
        {
            if (id != usuarioModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    _usuariorepositorio.Editar(usuarioModel);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception erro)
                {
                    TempData["MensagemErro"] = $"OPS! Usuário não foi editado com sucesso!, Detalhe do erro: {erro.Message}";

                    if (!UsuarioModelExists(usuarioModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuarioModel);
        }

        // GET: Usuario/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var usuarioModel = _usuariorepositorio.Busca(id);
            if (usuarioModel == null)
            {
                return NotFound();
            }

            return View(usuarioModel);
        }
        
        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                TempData["MensagemSucesso"] = "Usuário deletado com sucesso.";
                var usuarioModel = _usuariorepositorio.Busca(id);
                if (usuarioModel == null)
                {
                    return Problem("Não é possível apagar este usuário.");
                }
                if (usuarioModel != null)
                {
                    _usuariorepositorio.Apagar(usuarioModel);
                }
            } 
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"OPS! Usuário não foi apagado com sucesso!, Detalhe do erro: {erro.Message}";
            } 
            return RedirectToAction("Index");
        }
        private bool UsuarioModelExists(int id)
        {
            return _usuariorepositorio.Busca(id) == null ? false : true;
        }
    }
}
