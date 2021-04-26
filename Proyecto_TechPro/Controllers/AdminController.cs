using Proyecto_TechPro.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
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
            using (var contexto = new ProyectoPrograEntities())
            {
                var resultado = (from o in contexto.Ordenes
                                 from p in contexto.Productos
                                 from u in contexto.usuario
                                 from c in contexto.Categoria
                                 where p.idProducto == o.idProducto
                                 where u.idUsuario == o.idUsuario
                                 where c.idCategoria == o.idCategoria
                                 select new
                                 {
                                     o.idOrden,
                                     o.estado,
                                     p.nombreProducto,
                                     p.precio,
                                     o.direccion,
                                     u.nombre,
                                     u.primerApellido,
                                     u.segundoApellido,
                                     u.telefono,
                                     c.nombreCategoria
                                 }).ToList();

                if (resultado != null)
                {
                    List<OrdenesEnt> ord = new List<OrdenesEnt>();

                    foreach (var item in resultado)
                    {
                        ord.Add(new OrdenesEnt
                        {
                            idOrden = item.idOrden,
                            estado = item.estado,
                            nombreProd = item.nombreProducto,
                            precio = item.precio,
                            direccion = item.direccion,
                            nombreUsuario = item.nombre,
                            primerApellido = item.primerApellido,
                            segundoApellido = item.segundoApellido,
                            telefono = item.telefono,
                            nombreCat = item.nombreCategoria
                        });
                    }
                    return View(ord);
                }
                else
                {
                    ViewBag.Productos = "No existen ordenes disponibles";
                    return View();
                }



            }
        }



        public ActionResult Productos()
        {
            CargarViewBag();

            return View();
        }
        public ActionResult confirmarItem(string item)
        {
            int val = int.Parse(item);
            using (var contexto = new ProyectoPrograEntities())
            {
                var result = (from x in contexto.Ordenes
                              where x.idOrden == val
                              select x).FirstOrDefault();

                if (result != null)
                {
                    result.estado = "Enviado";
                    contexto.SaveChanges();
                    string vari = result.estado;
                    return Json(vari, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(null, JsonRequestBehavior.AllowGet);
                }
                

            }
        }

        public ActionResult InsertaProducto(Producto prod)
        {
            
            using (var contexto = new ProyectoPrograEntities())
            {
                var resultado = (from x in contexto.Productos
                                 where x.nombreProducto == prod.nombreProducto
                                 select x).FirstOrDefault();
                if (resultado == null)
                {
                    string filename = Path.GetFileNameWithoutExtension(prod.imageFile.FileName);
                    string extension = Path.GetExtension(prod.imageFile.FileName);
                    filename = filename + extension;
                    filename = Path.Combine(Server.MapPath("~/images/productos"), filename);
                    prod.imageFile.SaveAs(filename);
                    Productos p = new Productos();
                    p.nombreProducto = prod.nombreProducto;
                    p.idCategoria = prod.idCategoria;
                    p.imagen = prod.imagen;
                    p.precio = prod.precio;
                    p.descripcion = prod.descripcion;
                    contexto.Productos.Add(p);
                    contexto.SaveChanges();

                    var resIn = (from x in contexto.Invetario
                                 from c in contexto.Productos
                                 where x.idProducto == c.idProducto && c.nombreProducto == prod.nombreProducto
                                 select x).FirstOrDefault();
                    if (resIn == null)
                    {
                        Invetario inv = new Invetario();
                        inv.idProducto = prod.idProducto;
                        inv.cantidad = prod.cantidad;
                        contexto.Invetario.Add(inv);
                        contexto.SaveChanges();
                    }
                    return View("Index");



                }
                else
                {
                    return View("Productos");
                }
            }
        }

        public void CargarViewBag()
        {
            using (var contexto = new ProyectoPrograEntities())
            {
                var res = (from x in contexto.Categoria
                           select x).ToList();

                List<SelectListItem> lista = new List<SelectListItem>();


                foreach (var item in res)
                {
                    lista.Add(new SelectListItem { Value = item.idCategoria.ToString(), Text = item.nombreCategoria });
                }

                ViewBag.comboCatProd = lista;
            }
        }
    }
}