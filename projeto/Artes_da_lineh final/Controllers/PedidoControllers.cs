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
            return View();
        }
        [HttpPost]
        public IActionResult Encomendas(Pedido p)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            PedidoRepository pr =new PedidoRepository();
            p.dataPedido=DateTime.Now;
            p.usuario=HttpContext.Session.GetString("nomeUsuarioUsuario");
            pr.insert(p);
            ViewBag.mensagem=$"Pedido {p.pedido} realizado com sucesso";
            return View();
        }
        public IActionResult Visualizar()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            PedidoRepository pr =new PedidoRepository();
            Pedido p=new Pedido();
            p.usuario=HttpContext.Session.GetString("nomeUsuarioUsuario");
            List<Pedido> lista=pr.select(p);
            return View(lista);
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