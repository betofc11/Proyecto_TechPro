using Proyecto_TechPro.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_TechPro.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CargarViewBag();

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
                    using (var contexto = new ProyectoPrograEntities())
                    {
                        int idP = int.Parse(item);
                        var resultado = (from x in contexto.Productos
                                         where x.idProducto == idP
                                         select x).FirstOrDefault();

                        if (resultado != null)
                        {
                            prod.Add(new Producto
                            {
                                idProducto = resultado.idProducto,
                                nombreProducto = resultado.nombreProducto,
                                precio = resultado.precio,
                                idCategoria = resultado.idCategoria,
                                descripcion = resultado.descripcion,
                                imagen = resultado.imagen,
                                estado = 1
                            });

                            Session["ProductosCarrito"] = prod;
                            Session["CantidadCarrito"] = 1;
                        }
                    }
                }
                else
                {
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
                            descripcion = items.descripcion,
                            estado = 1
                        });
                    }

                    using (var contexto = new ProyectoPrograEntities())
                    {
                        int idP = int.Parse(item);
                        var resultado = (from x in contexto.Productos
                                         where x.idProducto == idP
                                         select x).ToList();

                        var nuev = (from x in contexto.Productos
                                    where x.idProducto == idP
                                    select x).FirstOrDefault();


                        var sesionProductos = (List<Producto>)Session["ProductosCarrito"];

                        bool repeated = false;



                        foreach (var sesP in sesionProductos)
                        {
                            foreach (var res in resultado)
                            {
                                if (sesP.idProducto == res.idProducto)
                                {
                                    repeated = true;
                                }

                            }
                        }

                        if (!repeated)
                        {
                            prodNuevos.Add(new Producto
                            {
                                idProducto = nuev.idProducto,
                                nombreProducto = nuev.nombreProducto,
                                precio = nuev.precio,
                                idCategoria = nuev.idCategoria,
                                descripcion = nuev.descripcion,
                                imagen = nuev.imagen,
                                estado = 1
                            });

                            Session["ProductosCarrito"] = prodNuevos;
                            Session["CantidadCarrito"] = prodNuevos.Count;

                        }
                    else
                    {
                        foreach (var al in prodNuevos)
                        {
                            if (al.idProducto.ToString()== item)
                            {
                                al.estado = 1;
                                Session["ProductosCarrito"] = prodNuevos;
                                var Num = Int32.Parse(Session["CantidadCarrito"].ToString());
                                Session["CantidadCarrito"] = Num+1;

                            }

                        }


                    }
                }
                }
            string cantidad = Session["CantidadCarrito"].ToString();
            if (cantidad != null)
                {
                    return Json(cantidad, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.DenyGet);
                }
            
           

               
        }



        [HttpPost]
        public ActionResult Item(string item)
        {
            var Contador = 0;
            List<Producto> prodl = new List<Producto>();
            prodl = (List<Producto>)Session["ProductosCarrito"];
            foreach (var it in prodl)
            {

                if (it.estado == 2)
                {
                    Contador++;
                }
            }

            var cCarrito = (Int32.Parse(Session["CantidadCarrito"].ToString())) - Contador;

            string cantidad = cCarrito.ToString();
            if (cantidad != null)
            {
                return Json(cantidad, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(null, JsonRequestBehavior.DenyGet);
            }
        }

    
        //[HttpPost]
        public ActionResult FiltrarCategoria(Categoria p)
        {
            using (var contexto = new ProyectoPrograEntities())
            {
                var Productos = (from x in contexto.Categoria
                                 where x.idCategoria == p.idCategoria
                                 select x).ToList();

                return View("ConsultaCategoria", Productos);
            }
        }
        [HttpPost]
        public ActionResult ConsultaCategoria(string cat)
        {
            CargarViewBag();
           
                if (Session["ProductosCarrito"] == null)
                {
                    List<Producto> prod = new List<Producto>();
                    using (var contexto = new ProyectoPrograEntities())
                    {
                        int idP = int.Parse(cat);
                        var resultado = (from x in contexto.Productos
                                         where x.idCategoria == idP
                                         select x).FirstOrDefault();

                        if (resultado != null)
                        {
                            prod.Add(new Producto
                            {
                                idProducto = resultado.idProducto,
                                nombreProducto = resultado.nombreProducto,
                                precio = resultado.precio,
                                idCategoria = resultado.idCategoria,
                                descripcion = resultado.descripcion,
                                imagen = resultado.imagen
                            });

                            Session["ProductosCarrito"] = prod;
                            Session["CantidadCarrito"] = 1;
                        }
                    }
                }
                return View();
            
        }


    

            public void CargarViewBag()
        {
            using (var contexto = new ProyectoPrograEntities())
            {
                var res = (from x in contexto.Categoria
                           select x).ToList();

                List<SelectListItem> lista = new List<SelectListItem>();

                if (lista.Count == 0)
                {
                    lista.Add(new SelectListItem { Value = "", Text = "Todos" });
                }

                foreach (var item in res)
                {
                    lista.Add(new SelectListItem { Value = item.idCategoria.ToString(), Text = item.nombreCategoria });
                }

                ViewBag.comboCategorias = lista;
            }
        }

        public ActionResult SeleccionaCat(Productos cat)
        {

            CargarViewBag();

            if (cat.idCategoria != null)
            {
                using (var contexto = new ProyectoPrograEntities())
                {
                    var res = (from c in contexto.Productos
                               where c.idCategoria == cat.idCategoria
                               select c).ToList();

                    return View("Index", res);
                }
            }
            else
            {
                using (var contexto = new ProyectoPrograEntities())
                {
                    var res = (from c in contexto.Productos
                               select c).ToList();

                    return View("Index", res);
                }
            }
            
        }
    }
}