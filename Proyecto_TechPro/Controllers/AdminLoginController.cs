using Proyecto_TechPro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_TechPro.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IniciarSesion(Admin admin)
        {
            using (var contexto = new ProyectoPrograEntities())
            {
                if (admin.pass != null && admin.email != null)
                {
                    var result = (from x in contexto.administrador
                                  where x.email == admin.email && x.adminPass == admin.pass
                                  select x).FirstOrDefault();

                    if (result != null)
                    {
                        List<Admin> adminUs = new List<Admin>();

                        adminUs.Add(new Admin
                        {
                            cedula = result.cedula,
                            email = result.email,
                            idAdmin = result.idAdmin,
                            nombre = result.nombre,
                            primerApellido = result.primerApellido,
                            segundoApellido = result.segundoApellido,
                            logueado = true
                        });

                        Session["adminUser"] = adminUs;
                        return RedirectToAction("RegistrarAdmin", "AdminLogin");
                    }
                }
                ViewBag.Message = "El correo electronico o la contrasena no son validos";
                return View("Index");
            }
        }

        public ActionResult RegistrarAdmin()
        {
            return View();
        }

            public ActionResult Registrarse(Admin admin)
            {
                using (var contexto = new ProyectoPrograEntities())
                {
                    var resultado = (from x in contexto.administrador
                                     where x.email == admin.email
                                     select x).FirstOrDefault();
                    if (resultado == null &&
                                       admin.email != null &&
                                       admin.nombre != null &&
                                       admin.primerApellido != null &&
                                       admin.segundoApellido != null &&
                                       admin.pass != null &&
                                       admin.pass2 != null &&
                                       admin.cedula != null)
                    {
                        if (admin.pass == admin.pass2)
                        {
                            administrador ad = new administrador();
                            ad.email = admin.email;
                            ad.nombre = admin.nombre;
                            ad.primerApellido = admin.primerApellido;
                            ad.segundoApellido = admin.segundoApellido;
                            ad.cedula = admin.cedula;
                            ad.adminPass = admin.pass;
                            contexto.administrador.Add(ad);
                            contexto.SaveChanges();
                            ViewBag.Message = "Se ha registrado exitosamente!";
                            return View("Index");
                        }
                    }
                    return View("RegistrarAdmin");
                }
            }
        }
    }
