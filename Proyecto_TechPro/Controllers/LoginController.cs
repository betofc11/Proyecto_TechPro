using Proyecto_TechPro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reactive.Subjects;
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

        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
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
                    Usuario user = new Usuario();
                    user.idUsuario = resultado.idUsuario;
                    user.nombre = resultado.nombre;
                    user.primerApellido = resultado.primerApellido;
                    user.segundoApellido = resultado.segundoApellido;
                    user.telefono = resultado.telefono;
                    user.email = resultado.email;

                    Session["userID"] = user;
                }
            }
            return RedirectToAction("Index", "Home");
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
                                   user.email != null &&
                                   user.nombre != null &&
                                   user.primerApellido != null &&
                                   user.segundoApellido != null &&
                                   user.Pass != null &&
                                   user.Pass2 != null &&
                                   user.telefono != null)
                {
                    if (user.Pass == user.Pass2)
                    {
                        usuario us = new usuario();
                        us.email = user.email;
                        us.nombre = user.nombre;
                        us.primerApellido = user.primerApellido;
                        us.segundoApellido = user.segundoApellido;
                        us.telefono = user.telefono;
                        us.Pass = user.Pass;
                        contexto.usuario.Add(us);
                        contexto.SaveChanges();
                        ViewBag.Message = "Se ha registrado exitosamente!";
                        return View("Login");
                    }
                }
                return View("Registrarse");
            }
        }

        public ActionResult RecuperarContrasena()
        {
            //ViewBag.Message = "Revise su correo, se le ha enviado un";
            return View("RecuperarContrasena");
        }

        [HttpPost]
        public ActionResult olvidoContrasena(string email)
        {
            string mensaje = "";
            bool restado = false;

            using (var contexto = new ProyectoPrograEntities())
            {
                var resultado = contexto.usuario.Where(x => x.email == email).FirstOrDefault();
                if (resultado != null)
                {
                    //enviar email para restablecer contraseña
                    string resetCode = Guid.NewGuid().ToString();
                    enviarCorreoRecuperacion(resultado.email, resetCode, "RecuperarContrasena");
                    resultado.Pass = resetCode;
                    //La siguiente linea de código sirve para saltarse la validación de contraseñas no concordantes
                    contexto.Configuration.ValidateOnSaveEnabled = false;
                    contexto.SaveChanges();
                    mensaje = "Un correo electrónico se le ha enviado para restablecer su contraseña.";
                }
                else
                {
                    mensaje = "La cuenta no fue encontrada";
                }
            }
            ViewBag.Message = mensaje;
            return View();
        }

        public void enviarCorreoRecuperacion(string correo, string activationCode, string emailFor = "RecuperarContrasena")
        {
            var verifyUrl = "/Usuario/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("TechPro@noreply.com", "Tech Pro");
            var toEmail = new MailAddress(correo);
            var fromEmailPassword = "*";

            string subject = "Reiniciar contraseña";
            string body = "Hola <br/> Recibimos una consulta para reiniciar tu contraseña. Por favor entre al siguiente enlace para restablecer su contraseña " +
            "<br/> <a href=" + link + "Reiniciar contraseña</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gamil.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }
        public ActionResult RestablecerContrasena(string email)
        {
            using (var contexto = new ProyectoPrograEntities())
            {
                var resultado = contexto.usuario.Where(x => x.email == email).FirstOrDefault();
                if (resultado != null)
                {
                    passReset model = new passReset();
                    model.ResetCode = email;
                    return View();
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        public ActionResult Perfil()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult ResetPassword(Usuario model)
        //{
        //    var mensaje = "";
        //    if (ModelState.IsValid)
        //    {
        //        using (var contexto = new ProyectoPrograEntities())
        //        {
        //            var resultado = contexto.usuario.Where(x => x.Reset == email).FirstOrDefault();
        //            if (resultado != null)
        //            {
        //                resultado.
        //            }
        //        }
        //    }
        //}
    }
}