using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Empleado
    {
        public int EmpleadoID { get; set; }
        public int legajo { get; set; }
        public int dni { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String email { get; set; }
        public String fechaNac { get; set; }
        [ForeignKey("domicilio")]
        public int idDomicilio { get; set; }
        public Domicilio domicilio { get; set; }
        [ForeignKey("puesto")]
        public int idPuesto { get; set; }
        public Puesto puesto { get; set; }
    }
}
