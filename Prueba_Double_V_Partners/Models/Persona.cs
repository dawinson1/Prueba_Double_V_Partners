using System.ComponentModel.DataAnnotations;

namespace Prueba_Double_V_Partners.Models
{
    public class Persona
    {
        [Required(ErrorMessage = "El Campo {0} Requerido")]
        [StringLength(maximumLength: 30)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "El Campo {0} Requerido")]
        [StringLength(maximumLength: 30)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El Campo {0} Requerido")]
        [StringLength(maximumLength: 15)]
        [Display(Name ="Número de Identificación")]
        public string Numero_Identificacion { get; set; }

        [Required(ErrorMessage = "El Campo {0} Requerido")]
        [StringLength(maximumLength: 100)]
        [EmailAddress(ErrorMessage ="El  campo debe ser un correo electrónico válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Campo {0} Requerido")]
        [Display(Name = "Tipo de Identificación")]
        public string Tipo_Identificacion { get; set; }

    }
}
