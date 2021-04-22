using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Proyecto_TechPro.Entidades;

namespace Proyecto_TechPro.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        public ActionResult Index()
        {


            if (ViewBag.CantidadCarrito == null)
            {
                ViewBag.CantidadCarrito = 0;
            }

            using (var contexto = new ProyectoPrograEntities())
            {
                var resultado = (from x in contexto.Productos
                                 select x).ToList();
                return View(resultado);
            }
        }


        public ActionResult CarritoView()
        {

            using (var contexto = new ProyectoPrograEntities())
            {
                





                if (Session["ProductosCarrito"] == null)
                {
                    ViewBag.Message = "NO HAY NADA";

                }
                else
                {
                    var idp = Int64.Parse( Session["ProductosCarrito"]);
                    var resultado = (from x in contexto.Productos
                                     where x.idProducto==idp
                                     select x).ToList();
                    List<Producto> prods = new List<Producto>();
                    prods = (List<Producto>)Session["ProductosCarrito"];

                    List<Producto> prodNuevos = new List<Producto>();
                    foreach (var items in prods)
                    {


                        
                        prodNuevos.Add(new Producto
                        {
                            idProducto = items.idProducto,
                            nombreProducto = items.nombreProducto,
                            precio = items.precio,
                            idCategoria = items.idCategoria,
                            imagen = items.imagen,
                            descripcion = items.descripcion
                        });
                    }
                }
                return View(resultado);
            }

        }

    }
}