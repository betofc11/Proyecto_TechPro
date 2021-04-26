using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
//using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Proyecto_TechPro.Entidades;
using System.Web.Mvc.Async;

namespace Proyecto_TechPro.Controllers
{
    public class CarritoController : Controller
    {


        public ActionResult CarritoView()
        {

            //int idPs = int.Parse(idp);k
            //int idPs = int.Parse(idp);k
            using (var contexto = new ProyectoPrograEntities())
            {


                List<Producto> prods = new List<Producto>();
                prods = (List<Producto>)Session["ProductosCarrito"];

                var Suma = 0;
                if (Session["ProductosCarrito"] != null)
                {
                    foreach (var items in prods)
                    {
                        Suma = (int)(Suma + items.precio);
                    }

                }
                ViewBag.Total = Suma;
                return View(prods);
            }

        }


        public ActionResult EliminaCarrito(int Producto)
        {


            using (var contexto = new ProyectoPrograEntities())
            {


                List<Producto> prods = new List<Producto>();

                prods = (List<Producto>)Session["ProductosCarrito"];

                List<Producto> prodsT = new List<Producto>();
                //prodsT = (List<Producto>)Session["ProductosCarrito"];
                foreach (var item in prods)
                {
                    prodsT.Add(new Producto
                    {
                        idProducto = item.idProducto,
                        nombreProducto = item.nombreProducto,
                        descripcion = item.descripcion,
                        precio = item.precio,
                        estado = item.estado,
                        idCategoria = item.idCategoria,
                        imagen = item.imagen
                    });
                }
                foreach (var p in prods)
                {


                    if (p.idProducto == Producto)
                    {

                        var itemToRemove = prodsT.Single(r => r.idProducto == Producto);
                        prodsT.Remove(itemToRemove);

                        //p.estado = 2;
                        //Session["ProductosCarrito"] = prods;

                    }

                }
                //var Contador = 0;

                //foreach (var it in prods)
                //{

                //    if (it.estado == 2)
                //    {
                //        Contador++;
                //    }
                //}
                Session["ProductosCarrito"] = prodsT;
                Session["CantidadCarrito"] = prodsT.Count;

                return View(prodsT);

            }
        }

        public ActionResult FinalizarPedido (int Producto)
        {
            return View();
        }

            //public ActionResult EliminaCarrito(int Producto)
            //{


            //    using (var contexto = new ProyectoPrograEntities())
            //    {


            //        List<Producto> prods = new List<Producto>();

            //        prods = (List<Producto>)Session["ProductosCarrito"];
            //        var eliminado = false;
            //            for(int i=0;i<=prods.Count-1;i++)
            //            {
            //            //while (eliminado != true) 
            //            //{
            //                var p = prods[i];
            //                if (p.idProducto == Producto)
            //                {
            //                    var x = prods.Remove(p);
            //                    Session["ProductosCarrito"] = prods;
            //                    Session["CantidadCarrito"] = prods.Count;
            //                    eliminado = true;
            //                    i = prods.Count;
            //                }
            //                else
            //                {
            //                    i++;
            //                }

            //            //}

            //            }


            //        return View (prods);

            //    }
            //}

            // GET: Carrito



            //public ActionResult CarritoView()
            //{
            //    var nuevos = "";
            //    //int idPs = int.Parse(idp);
            //    using (var contexto = new ProyectoPrograEntities())
            //    {


            //        List<Producto> prods = new List<Producto>();
            //        prods = (List<Producto>)Session["ProductosCarrito"];



            //        if (Session["ProductosCarrito"] == null)
            //        {
            //            ViewBag.Message = "NO HAY NADA";

            //        }
            //        else
            //        {

            //            List<Producto> prodNuevos = new List<Producto>();
            //            foreach (var items in prods)
            //            {



            //                prodNuevos.Add(new Producto
            //                {
            //                    idProducto = items.idProducto,
            //                    nombreProducto = items.nombreProducto,
            //                    precio = items.precio,
            //                    idCategoria = items.idCategoria,
            //                    imagen = items.imagen,
            //                    descripcion = items.descripcion
            //                });



            //                var resultado = (from x in contexto.Productos
            //                                 where x.idProducto == items.idProducto
            //                         select x).ToList();


            //                 View(resultado);
            //            }


            //        }

            //        return View();
            //    }

            //}
            //public Task<ActionResult> VistaProductos(string id)
            //{
            //    var idP = Int64.Parse(id);
            //    string Produc = " ";
            //    using (var contexto = new ProyectoPrograEntities())
            //    {
            //        var Productos = (from x in contexto.Productos
            //                         where x.idProducto == idP
            //                         select x).FirstOrDefault();

            //        Produc = Productos.ToString();

            //    }
            //    return (Productos);
            //}
    
    }




}