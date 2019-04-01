﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace pruebaempleadosbe.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190331215317_mig1")]
    partial class mig1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Empleado", b =>
                {
                    b.Property<int>("EmpleadoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido");

                    b.Property<int>("dni");

                    b.Property<string>("email");

                    b.Property<string>("fechaNac");

                    b.Property<int>("idPuesto");

                    b.Property<string>("nombre");

                    b.HasKey("EmpleadoID");

                    b.HasIndex("idPuesto");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Models.Puesto", b =>
                {
                    b.Property<int>("PuestoID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre");

                    b.HasKey("PuestoID");

                    b.ToTable("Puestos");
                });

            modelBuilder.Entity("Models.Empleado", b =>
                {
                    b.HasOne("Models.Puesto", "puesto")
                        .WithMany()
                        .HasForeignKey("idPuesto")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}