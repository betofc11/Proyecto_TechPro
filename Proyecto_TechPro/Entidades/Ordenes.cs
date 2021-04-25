using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_TechPro.Entidades
{
    public class OrdenesEnt
    {
        public int idOrden { get; set; }
        public int? precio { get; set; }
        public string estado { get; set; }
        public string nombreProd { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string codPostal { get; set; }
        public string dirExact { get; set; }
        public string indica { get; set; }
        public string nombreUsuario { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string telefono { get; set; }
        public string nombreCat { get; set; }
    }
}