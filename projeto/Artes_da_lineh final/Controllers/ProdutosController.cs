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
            try
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
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de listagem de produtos";
                return View("../Home/Erro");         
            }
            
        }
        public IActionResult Inserir()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            else
            {
                if(HttpContext.Session.GetInt32("tipoUsuarioUsuario")==1)
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
            try
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
                {
                    return RedirectToAction("Login","Usuario");
                }
                ProdutoRepository pr =new ProdutoRepository();
                pr.insert(p);
                return RedirectToAction("Menu","Home");
            }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de inserção de produtos";
                return View("../Home/Erro");  
            }
        }
        public IActionResult Modificar()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            else
            {
                if(HttpContext.Session.GetInt32("tipoUsuarioUsuario")==1)
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
            try
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
                {
                    return RedirectToAction("Login","Usuario");
                }
                ProdutoRepository pr =new ProdutoRepository();
                pr.update(p);
                return RedirectToAction("Menu","Home"); 
                }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de edição de produtos";
                return View("../Home/Erro");  
            }
            
        }
        public IActionResult Excluir()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            else
            {
                if(HttpContext.Session.GetInt32("tipoUsuarioUsuario")==1)
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
            try
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
                {
                    return RedirectToAction("Login","Usuario");
                }
                ProdutoRepository pr = new ProdutoRepository();
                pr.delete(p);
                return RedirectToAction("Menu","Home");
            }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de edição de produtos";
                return View("../Home/Erro");  
            }
           
        }

        public IActionResult Product(int id){
            try
            {
                ViewModel viewModel = new ViewModel();
                viewModel.produtoRepository = new ProdutoRepository();
                viewModel.listaProduto = viewModel.produtoRepository.product(id);
                viewModel.usuarioRepository = new UsuarioRepository();
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")!=null){
                    viewModel.listaUsuario = viewModel.usuarioRepository.foto(HttpContext.Session.GetInt32("idUsuarioUsuario"));
                }
                viewModel.listaProduto1 = viewModel.produtoRepository.select();
                foreach (Produto item in viewModel.listaProduto1)
                {
                    if(id>viewModel.listaProduto1.Count){
                        return RedirectToAction("Produtos","Produtos");
                    }
                }
                return View(viewModel);
            }
            catch (Exception e)
            {               
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de visualização de produto";
                return View("../Home/Erro");  
            }         
        }
    }
}