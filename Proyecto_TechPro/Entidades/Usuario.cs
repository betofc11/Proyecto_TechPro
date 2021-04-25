using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyecto_TechPro.Entidades
{
    public class Usuario
    {
        [Required]
        [Display(Name = "cédula")]
        public int idUsuario { get; set; }
        [Required]
        [Display(Name = "teléfono")]
        public string telefono { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "correo electrónico")]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "La {0} debe tener al menos 8 caracteres", MinimumLength = 8)]
        [Display(Name = "contraseña")]
        public string Pass { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "La {0} debe tener al menos 8 caracteres", MinimumLength = 8)]
        [Display(Name = "confirmar contraseña")]
        [Compare("Pass", ErrorMessage = "Las contraseñas no coinciden")]
        public string Pass2 { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        [Display(Name = "primer apellido")]
        public string primerApellido { get; set; }
        [Required]
        [Display(Name = "segundo apellido")]
        public string segundoApellido { get; set; }
    }


}