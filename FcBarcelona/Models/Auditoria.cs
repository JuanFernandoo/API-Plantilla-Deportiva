namespace FcBarcelona.Models
{
    public class Auditoria // Valores de la tabla Auditoria
    {
        public int Id { get; set; }
        public string ? Accion { get; set; }
        public string ? Tabla { get; set; }
        public string ? DatosAnteriores { get; set; }
        public string ? DatosNuevos { get; set; }
        public DateTime Fecha { get; set; }
        public string ? Usuario { get; set; }
        public string ? PC { get; set; }
    }
}
