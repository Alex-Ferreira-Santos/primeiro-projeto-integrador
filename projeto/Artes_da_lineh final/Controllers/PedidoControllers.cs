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
        public IActionResult Encomendas(string nome="")
        {
            try
            {
                ViewModel viewModel = new ViewModel();
                viewModel.nome = nome;
                viewModel.usuarioRepository = new UsuarioRepository();
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")!=null){
                    viewModel.listaUsuario = viewModel.usuarioRepository.foto(HttpContext.Session.GetInt32("idUsuarioUsuario"));
                }
                return View(viewModel);
            }
            catch (Exception e)
            { 
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de carregamento da pagina de encomendas";
                return View("../Home/Erro");  
            }
            
        }
        [HttpPost]
        public IActionResult Encomendas(ViewModel p)
        {
            try
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
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de criação de encomendas";
                return View("../Home/Erro");  
            }
            
        }
        public IActionResult Visualizar()
        {
            try
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
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de visualização de encomendas";
                return View("../Home/Erro");  
            }
        }
        public IActionResult Uvisualizar()
        {
            try
            {
                if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
                {
                    return RedirectToAction("Login","Usuario");
                }else{
                    if(HttpContext.Session.GetInt32("tipoUsuarioUsuario")==0){
                        PedidoRepository pr =new PedidoRepository();
                        Pedido p = new Pedido();
                        p.usuario=HttpContext.Session.GetString("nomeUsuarioUsuario");
                        List<Pedido> lista=pr.selectU(p);
                        return View(lista);
                    }else{
                        return RedirectToAction("Index","Home");
                    }
                }
            }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de visualização de encomendas";
                return View("../Home/Erro");       
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
            try
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
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de edição de encomendas";
                return View("../Home/Erro");   
            }
            
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
            try
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
            catch (Exception e)
            {             
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de exclusão de encomendas";
                return View("../Home/Erro");  
            }
            
        }
    }
}