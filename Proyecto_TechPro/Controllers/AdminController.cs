using Proyecto_TechPro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_TechPro.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
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
                        return View("Productos");
                    }
                }

                return View("Index");
            }
        }

        public ActionResult Productos()
        {
            using (var contexto = new ProyectoPrograEntities())
            {
                var resultado = (from x in contexto.)
            }
            return View();
        }
    }
}