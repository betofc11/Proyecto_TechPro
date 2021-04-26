using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_TechPro.Entidades
{
    public class Admin
    {
        public string email { get; set; }
        public string pass { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string cedula { get; set; }
        public int idAdmin { get; set; }
        public bool logueado { get; set; }
    }
}