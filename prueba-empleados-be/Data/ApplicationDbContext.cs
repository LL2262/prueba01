using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Barrio> Barrios { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
    }
}
