using Proyecto_TechPro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_TechPro.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult iniciarSesion(Usuario usuario)
        {
            using (var contexto = new ProyectoPrograEntities())
            {
                var resultado = contexto.usuario.Where(x => x.email == usuario.email && x.Pass == usuario.Pass).FirstOrDefault();
                if (resultado == null)
                {
                    ViewBag.Message = "El correo electronico o la contrasena no son validos";
                    return View("Login", usuario);
                }
                else
                {
                    Session["userID"] = resultado;
                }
            }
            ViewBag.Message = "¡Bienvenido " + usuario.nombre + "!";    
            return RedirectToAction("Index","Home");
            }

            public ActionResult Registrarse()
        {
            return View("Registrarse");
        }

        public ActionResult RegistrarUsuario(Usuario user)
        {
            using (var contexto = new ProyectoPrograEntities())
            {
                var resultado = (from x in contexto.usuario
                                 where x.email == user.email
                                 select x).FirstOrDefault();
                if (resultado == null && 
                    user.idUsuario > 0 && 
                    user.email != null && 
                    user.nombre != null &&
                    user.primerApellido != null &&
                    user.segundoApellido != null &&
                    user.Pass != null &&
                    user.Pass2 != null &&
                    user.telefono > 0)
                {
                    if (user.Pass == user.Pass2)
                    {
                        usuario us = new usuario();
                        us.idUsuario = user.idUsuario;
                        us.email = user.email;
                        us.nombre = user.nombre;
                        us.primerApellido = user.primerApellido;
                        us.segundoApellido = user.segundoApellido;
                        us.telefono = user.telefono;
                        us.Pass = user.Pass;
                        contexto.usuario.Add(us);
                        contexto.SaveChanges();
                        return View("Login");
                    }
                }
                return View("Registrarse");
           }
        }

        public ActionResult RecuperarContrasena()
        {
            return View("RecuperarContrasena");
        }

    }
}