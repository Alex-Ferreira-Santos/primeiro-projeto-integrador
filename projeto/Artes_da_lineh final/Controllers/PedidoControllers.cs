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
    public class PedidoController : Controller
    {
        public IActionResult Encomendas()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.usuarioRepository = new UsuarioRepository();
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")!=null){
                viewModel.listaUsuario = viewModel.usuarioRepository.foto(HttpContext.Session.GetInt32("idUsuarioUsuario"));
            }
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Encomendas(ViewModel p)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            ViewModel viewModel = new ViewModel();
            viewModel.pedidoRepository = new PedidoRepository();
            p.pedido.dataPedido = DateTime.Now;
            p.pedido.usuario = HttpContext.Session.GetString("nomeUsuarioUsuario");
            viewModel.pedidoRepository.insert(p.pedido);
            ViewBag.mensagem=$"Pedido {p.pedido} realizado com sucesso";
            viewModel.usuarioRepository = new UsuarioRepository();
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")!=null){
                viewModel.listaUsuario = viewModel.usuarioRepository.foto(HttpContext.Session.GetInt32("idUsuarioUsuario"));
            }
            return View(viewModel);
        }
        public IActionResult Visualizar()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            PedidoRepository pr =new PedidoRepository();
            Pedido p=new Pedido();
            List<Pedido> lista=pr.select(p);
            return View(lista);
        }
        public IActionResult Uvisualizar()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }else{
                if(HttpContext.Session.GetInt32("tipoUsuarioUsuario")==0){
                    PedidoRepository pr =new PedidoRepository();
                    Pedido p = new Pedido();
                    p.usuario=HttpContext.Session.GetString("nomeUsuarioUsuario");
                    List<Pedido> lista=pr.select(p);
                    return View(lista);
                }else{
                    return RedirectToAction("Index","Home");
                }
            }
            
        }
        public IActionResult Modificar()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Modificar(Pedido p)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            PedidoRepository pr =new PedidoRepository();
            p.usuario=HttpContext.Session.GetString("nomeUsuarioUsuario");
            p.dataPedido=DateTime.Now;
            pr.update(p);
            ViewBag.mensagem=$"Pedido {p.pedido} modificado com sucesso";
            return View();
        }
        public IActionResult Excluir()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Excluir(Pedido p)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            PedidoRepository pr =new PedidoRepository();
            ViewBag.mensagem=$"Pedido {p.pedido} excluido com sucesso";
            pr.delete(p);
            return View();
        }
    }
}