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
            ViewModel viewModel = new ViewModel();
            viewModel.desenhosRepository = new DesenhosRepository();
            viewModel.listaDesenhos = viewModel.desenhosRepository.select();
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
        public IActionResult Inserir(Desenhos d)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            DesenhosRepository pr =new DesenhosRepository();
            pr.insert(d);
            ViewBag.mensagem=$"Desenho {d.imagem} inserido com sucesso";
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
        public IActionResult Modificar(Desenhos d)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            DesenhosRepository pr =new DesenhosRepository();
            pr.update(d);
            ViewBag.mensagem=$"Desenho {d.imagem} modificado com sucesso";
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
        public IActionResult Excluir(Desenhos d)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            DesenhosRepository pr =new DesenhosRepository();
            ViewBag.mensagem=$"Produto {d.imagem} excluido com sucesso";
            pr.delete(d);
            return View();
        }
        public IActionResult _Desenhos(){
            ViewModel viewModel = new ViewModel();
            viewModel.desenhosRepository = new DesenhosRepository();
            viewModel.listaDesenhos = viewModel.desenhosRepository.main();
            return PartialView(viewModel);
        }
    }
}