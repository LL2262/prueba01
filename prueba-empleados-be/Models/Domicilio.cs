using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Domicilio
    {
        public int DomicilioID { get; set; }
        public int calle { get; set; }
        public int numero { get; set; }
        [ForeignKey("barrio")]
        public int idBarrio { get; set; }
        public Barrio barrio { get; set; }
    }
}
