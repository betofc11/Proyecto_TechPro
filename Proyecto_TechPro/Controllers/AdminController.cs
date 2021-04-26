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
            using (var contexto = new ProyectoPrograEntities())
            {
                var resultado = (from o in contexto.Ordenes
                                 from p in contexto.Productos
                                 from d in contexto.Direccion
                                 from u in contexto.usuario
                                 from c in contexto.Categoria
                                 where p.idProducto == o.idProducto
                                 where d.idDireccion == o.idDireccion
                                 where u.idUsuario == o.idUsuario
                                 where c.idCategoria == o.idCategoria
                                 select new
                                 {
                                     o.idOrden,
                                     o.estado,
                                     p.nombreProducto,
                                     p.precio,
                                     d.provincia,
                                     d.canton,
                                     d.codigoPostal,
                                     d.dirExacta,
                                     d.indicaciones,
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
                            provincia = item.provincia,
                            canton = item.canton,
                            codPostal = item.codigoPostal,
                            dirExact = item.dirExacta,
                            indica = item.indicaciones,
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
            return View();
        }
        public ActionResult confirmarItem(string item)
        {
            using (var contexto = new ProyectoPrograEntities())
            {
                var 
            }
            return View();
        }
    }
}