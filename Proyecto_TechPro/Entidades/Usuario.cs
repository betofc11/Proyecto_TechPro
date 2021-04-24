using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_TechPro.Entidades
{
    public class Usuario { 
    public int idUsuario { get; set; }
    public Nullable<int> telefono { get; set; }
    public string email { get; set; }
    public string Pass { get; set; }
    public string Pass2 { get; set; }
    public string nombre { get; set; }
    public string primerApellido { get; set; }
    public string segundoApellido { get; set; }
    }   


}