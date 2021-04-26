using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_TechPro.Entidades
{
    public class Admin
    {
        [Required]
        [EmailAddress]
        [Display(Name = "correo electrónico")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "La {0} debe tener al menos 8 caracteres", MinimumLength = 8)]
        [Display(Name = "contraseña")]
        public string pass { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "La {0} debe tener al menos 8 caracteres", MinimumLength = 8)]
        [Display(Name = "confirmar contraseña")]
        [Compare("pass", ErrorMessage = "Las contraseñas no coinciden")]
        public string pass2 { get; set; }
        [Required]
        [Display(Name = "nombre")]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "primer apellido")]
        public string primerApellido { get; set; }
        [Required]
        [Display(Name = "segundo apellido")]
        public string segundoApellido { get; set; }
        [Required]
        [Display(Name = "cédula")]
        public string cedula { get; set; }
        [Required]
        [Display(Name = "ID admin")]
        public int idAdmin { get; set; }
        public bool logueado { get; set; }
    }
}