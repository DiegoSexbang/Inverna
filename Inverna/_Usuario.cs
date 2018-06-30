using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inverna
{
    [MetadataType(typeof(usuario_meta))]
    public partial class Usuario
    {
    }
    public class usuario_meta
    {
        [Display(Name = "Nombre Usuario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre de usuario es requerido")]
        public string nombreusuario { get; set; }


        [Display(Name = "Contraseña")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "La contraseña es requerida")]
        public string contrasenausuario { get; set; }
    }
}