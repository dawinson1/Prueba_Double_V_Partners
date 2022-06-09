using System.ComponentModel.DataAnnotations;

namespace Prueba_Double_V_Partners.Models
{
    public class Usuarios
    {
        [Required(ErrorMessage = "El Campo {0} Requerido")]
        [StringLength(maximumLength: 15)]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "El Campo {0} Requerido")]
        [StringLength(maximumLength: 30)]
        [Display(Name ="Contraseña")]
        public string Pass { get; set; }
    }
}
