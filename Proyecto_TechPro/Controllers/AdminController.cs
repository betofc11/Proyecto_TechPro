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
                var resultado = (from o in contexto.Ordenes
                                 from p in contexto.Productos
                                 from d in contexto.Direccion
                                 from u in contexto.usuario
                                 from c in contexto.Categoria
                                 where p.idProducto == o.idProducto
                                 where d.idDireccion == o.idDireccion
                                 where u.idUsuario == o.idUsuario
                                 where c.idCategoria == o.idCategoria
                                 select new { 
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
    }
}