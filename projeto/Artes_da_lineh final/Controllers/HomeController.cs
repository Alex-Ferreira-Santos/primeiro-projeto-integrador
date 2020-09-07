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
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.produtoRepository = new ProdutoRepository();
            viewModel.desenhosRepository = new DesenhosRepository();
            viewModel.listaProduto = viewModel.produtoRepository.main();
            viewModel.listaDesenhos = viewModel.desenhosRepository.main();
            return View(viewModel);
        }
        public IActionResult FaleConosco()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FaleConosco(Mensagem m)
        {
            ViewBag.mensagem="Mensagem enviada com sucesso";
            return View();
        }
        public IActionResult Menu()
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
    }
}
