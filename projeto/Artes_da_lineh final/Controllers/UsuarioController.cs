using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Artes_da_lineh_final.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Artes_da_lineh_final.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            try
            {
                UsuarioRepository ur=new UsuarioRepository();
                Usuario usuario=ur.login(u);
                if(usuario!=null)
                {
                    HttpContext.Session.SetInt32("idUsuarioUsuario",usuario.id);
                    HttpContext.Session.SetString("nomeUsuarioUsuario",usuario.nome);
                    HttpContext.Session.SetInt32("tipoUsuarioUsuario",usuario.tipo);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.mensagem="Falha no login";
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.mensagem = e.Message;
                ViewBag.processo = "processo de login de usuário";
                ViewBag.local = e.TargetSite;
                return View("../Home/Erro");
            }
            
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        public IActionResult Conta()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Conta(Usuario u)
        {
            UsuarioRepository ur=new UsuarioRepository();
            u.tipo=0;
            if(u.avatar==null){
                u.avatar="/imagens/user1.png";
            }
            ur.insert(u);
            return RedirectToAction("Login","Usuario");
        }
        public IActionResult Modificar()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Modificar(Usuario u)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            UsuarioRepository ur = new UsuarioRepository();

            if(HttpContext.Session.GetInt32("tipoUsuarioUsuario")==0){
                ur.updateU(u,HttpContext.Session.GetInt32("idUsuarioUsuario"));
            }
            if(HttpContext.Session.GetInt32("tipoUsuarioUsuario")==1){
                ur.updateA(u);
            }
            return RedirectToAction("Menu","Home");
        }
        public IActionResult Excluir()
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            else
            {
                if(HttpContext.Session.GetInt32("tipoUsuarioUsuario")==0)
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
        public IActionResult Excluir(Usuario u)
        {
            if(HttpContext.Session.GetInt32("idUsuarioUsuario")==null)
            {
                return RedirectToAction("Login","Usuario");
            }
            UsuarioRepository ur =new UsuarioRepository();
            ur.delete(u,HttpContext.Session.GetInt32("idUsuarioUsuario"));
            return RedirectToAction("Menu","Home");
        }
    }
}