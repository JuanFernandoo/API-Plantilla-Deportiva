using System;

namespace FcBarcelona.Models
{
    public class JWT // Clase que gestion la vericidad del token
    {
        public string ? ValidIssuer { get; set; }
        public string ? ValidAudience { get; set; }
        public string ? Secret { get; set; }
    }
}
