using Proyecto_TechPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_TechPro.Controllers
{
    public class ApiDireccionController : Controller
    {
        // GET: ApiDireccion
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult TraerValores(String nombre)
        {
            DireccionesModel tcm = new DireccionesModel();
            var respuesta = tcm.ConsultarP();

            if (respuesta != null)
            {
                respuesta.nombreCanton = nombre;
                respuesta.nombreProvincias = nombre;
                return Json(respuesta, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }
    }
}
