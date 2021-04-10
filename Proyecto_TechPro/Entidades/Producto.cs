using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_TechPro.Entidades
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public int idCategoria { get; set; }
        public string imagen { get; set; }
    }
}