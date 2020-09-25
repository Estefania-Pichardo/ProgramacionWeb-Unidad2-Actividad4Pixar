using System;
using System.Collections.Generic;

namespace U2Actividad4Routing.Models
{
    public partial class Personaje
    {
        public Personaje()
        {
            Apariciones = new HashSet<Apariciones>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Apariciones> Apariciones { get; set; }
    }
}
