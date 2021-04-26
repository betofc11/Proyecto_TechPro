using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_TechPro.Entidades
{
    public class Producto
    {
        
        public HttpPostedFileBase imageFile { get; set; }
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int? precio { get; set; }
        public string descripcion { get; set; }
        public int? idCategoria { get; set; }
        public int? cantidad { get; set; }
        public string imagen { get; set; }

        [DefaultValue(1)]
        public int estado { get; set; }


    }
}