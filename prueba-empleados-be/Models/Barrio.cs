using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Barrio
    {
        public int BarrioID { get; set; }
        public String nombre { get; set; }
        [ForeignKey("localidad")]
        public int idLocalidad { get; set; }
        public Localidad localidad { get; set; }
    }
}
