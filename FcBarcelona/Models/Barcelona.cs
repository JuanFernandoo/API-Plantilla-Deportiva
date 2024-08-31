using System.ComponentModel.DataAnnotations;

namespace FcBarcelona.Models
{
    public class Barcelona
    {
        public int Id { get; set; } // Clave primaria

        [Required(ErrorMessage = "Ingrese el nombre")] // Asegura que el nombre no esté vacío
        [MaxLength(1000, ErrorMessage = "El nombre no puede exceder los 1000 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la edad")] // Asegura que la edad no esté vacía
        [Range(1, 100, ErrorMessage = "La edad debe estar entre 1 y 100")] // Limita la edad 
        public int edad { get; set; }

        [Required(ErrorMessage = "Ingrese la posición")] // Asegura que la posición no esté vacía
        [MaxLength(70, ErrorMessage = "La posición no puede exceder los 70 caracteres")]
        public string? Posicion { get; set; }
    }
}

