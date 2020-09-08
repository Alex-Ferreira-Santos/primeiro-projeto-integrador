using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Artes_da_lineh_final.Models;
using Microsoft.AspNetCore.Http;

namespace Artes_da_lineh_final.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Produtos()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.produtoRepository = new ProdutoRepository();
            viewModel.listaProduto = viewModel.produtoRepository.select();
            viewModel.usuarioRepository = new UsuarioRepository();
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")!=null){
                viewModel.listaUsuario = viewModel.usuarioRepository.foto(HttpContext.Session.GetInt32("idUsuarioUsuario"));
            }
            return View(viewModel);
        }
        public IActionResult Inserir()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            else
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
        }
        [HttpPost]
        public IActionResult Inserir(Produto p)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            ProdutoRepository pr =new ProdutoRepository();
            pr.insert(p);
            ViewBag.mensagem=$"Produto {p.nome} inserido com sucesso";
            return View();
        }
        public IActionResult Modificar()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            else
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
        }
        [HttpPost]
        public IActionResult Modificar(Produto p)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            ProdutoRepository pr =new ProdutoRepository();
            pr.update(p);
            ViewBag.mensagem=$"Produto {p.nome} modificado com sucesso";
            return View();
        }
        public IActionResult Excluir()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            else
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==1)
                {
                    return View();
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
        }
        [HttpPost]
        public IActionResult Excluir(Produto p)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            ProdutoRepository pr =new ProdutoRepository();
            ViewBag.mensagem=$"Produto {p.nome} excluido com sucesso";
            pr.delete(p);
            return View();
        }
        public IActionResult _Produtos(){
            return PartialView();
        }
    }
}