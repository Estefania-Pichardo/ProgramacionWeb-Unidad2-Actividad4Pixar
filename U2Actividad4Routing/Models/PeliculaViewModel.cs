using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace U2Actividad4Routing.Models
{
    public class PeliculaViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreOriginal { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaEstreno { get; set; }

        public IEnumerable<Apariciones> Apariciones { get; set; }
    }
}
