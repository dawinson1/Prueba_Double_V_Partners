using System.ComponentModel.DataAnnotations;

namespace API_DB_Double_V_Partners.Models
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
        public string Numero_Identificacion { get; set; }

        [Required(ErrorMessage = "El Campo {0} Requerido")]
        [StringLength(maximumLength: 100)]
        [EmailAddress(ErrorMessage ="El  campo debe ser un correo electrónico válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El Campo {0} Requerido")]
        public string Tipo_Identificacion { get; set; }

    }
}
