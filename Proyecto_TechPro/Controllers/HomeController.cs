using Proyecto_TechPro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_TechPro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (ViewBag.CantidadCarrito == null)
            {
                ViewBag.CantidadCarrito = 0;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult AgregaItem(string item)
        {
            if (Session["ProductosCarrito"] == null)
            {

                List<Producto> prod = new List<Producto>();
                prod.Add(new Producto { idProducto = int.Parse(item), nombreProducto = "Primer producto", precio = 300, idCategoria = 001, descripcion = "xdd", imagen = "sjdncjhswdn" });

                Session["ProductosCarrito"] = prod;
                Session["CantidadCarrito"] = 1;
            }
            else
            {

                List<Producto> prod = new List<Producto>();
                prod = (List<Producto>)Session["ProductosCarrito"];

                List<Producto> prodNuevos = new List<Producto>();

                foreach (var items in prod)
                {
                    prodNuevos.Add(new Producto { idProducto = items.idProducto, nombreProducto = items.nombreProducto, precio = items.precio, idCategoria = items.idCategoria, imagen = items.imagen, descripcion = items.descripcion });
                }
                prodNuevos.Add(new Producto { idProducto = int.Parse(item), nombreProducto = "Primer producto", precio = 300, idCategoria = 001, descripcion = "xdd", imagen = "sjdncjhswdn" });
                Session["ArticulosCarrito"] = prodNuevos;
                Session["CantidadCarrito"] = prodNuevos.Count;
            }
            string cantidad = Session["CantidadCarrito"].ToString();
            ViewBag.CantidadCarrito = Session["CantidadCarrito"];

            return View("Index", cantidad);
        }
        [HttpPost]
        public ActionResult FiltrarCategoria()
        {
            

            return View();
        }

        public ActionResult ConsultaIndex()
        {
            //CargarViewBag();

            using (var contexto = new PracticaS13Entities())
            {
                var Productos = (from x in contexto.Principal
                                 select x).ToList();

                return View(Productos);
            }
        }

    }
}