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
    public class DesenhoController : Controller
    {
        public IActionResult Desenhos()
        {
            try
            {
                ViewModel viewModel = new ViewModel();
                viewModel.desenhosRepository = new DesenhosRepository();
                viewModel.listaDesenhos = viewModel.desenhosRepository.select();
                viewModel.usuarioRepository = new UsuarioRepository();
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")!=null){
                    viewModel.listaUsuario = viewModel.usuarioRepository.foto(HttpContext.Session.GetInt32("idUsuarioUsuario"));
                }
                return View(viewModel);
            }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de listagem dos desenhos";
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
        public IActionResult Inserir(Desenhos d)
        {
            try
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
                {
                    return RedirectToAction("Login","Usuario");
                }
                DesenhosRepository pr = new DesenhosRepository();
                pr.insert(d);
                return RedirectToAction("Menu","Home");
                }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de inserção dos desenhos";
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
        public IActionResult Modificar(Desenhos d)
        {
            try
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
                {
                    return RedirectToAction("Login","Usuario");
                }
                DesenhosRepository pr =new DesenhosRepository();
                pr.update(d);
                ViewBag.mensagem=$"Desenho {d.imagem} modificado com sucesso";
                return RedirectToAction("Menu","Home");
                }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de edição dos desenhos";
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
        public IActionResult Excluir(Desenhos d)
        {
            try
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
                {
                    return RedirectToAction("Login","Usuario");
                }
                DesenhosRepository pr =new DesenhosRepository();
                ViewBag.mensagem=$"Produto {d.imagem} excluido com sucesso";
                pr.delete(d);
                return RedirectToAction("Menu","Home");
                }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de exlcusão dos desenhos";
                return View("../Home/Erro"); 
            }
            
        }
        
    }
}