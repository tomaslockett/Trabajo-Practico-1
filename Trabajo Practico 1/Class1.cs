using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_1
{
    internal class Alumno
    {
        public Alumno()
        {

        }
        public Alumno(int PLegajo, string PNombre, string PApellido, DateTime PFecha_Nacimiento, DateTime PFecha_Ingreso, bool PActivo, int PCant_Materias_Aprobadas)
        {
            Legajo = PLegajo;
            Nombre = PNombre;
            Apellido = PApellido;
            Fecha_Nacimiento = PFecha_Nacimiento;
            Fecha_Ingreso = PFecha_Ingreso;

            Activo = PActivo;
            Cant_Materias_Aprobadas = PCant_Materias_Aprobadas;

        }
        public int Legajo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        private DateTime fecha_nacimiento;
        public DateTime Fecha_Nacimiento
        {
            set { fecha_nacimiento = value; }
        }

        private DateTime fecha_ingreso;

        public DateTime Fecha_Ingreso
        {
            set { fecha_ingreso = value; }
        }


        public int Edad
        {
            get
            {
                int edad;
                edad = DateTime.Now.Year - fecha_nacimiento.Year;
                if (fecha_nacimiento.Date > DateTime.Now.Date.AddYears(-edad))
                {
                    edad--;
                }
                return edad;
            }

        }

        public bool Activo { get; set; }

        private int cant_materias_aprobadas;

        public int Cant_Materias_Aprobadas
        {
            set { cant_materias_aprobadas = value; }
        }

        public int Antiguedad
        {
            get
            {
                TimeSpan diferencia = DateTime.Now - fecha_ingreso;
                return diferencia.Days;
            }
        }

        public int Materias_No_Aprobadas { get { return 36 - cant_materias_aprobadas; } }

        public int Edad_De_Ingreso
        {
            get
            {
                int edad;
                edad = fecha_ingreso.Year - fecha_nacimiento.Year;
                if (fecha_nacimiento.Date > fecha_ingreso.Date.AddYears(-edad))
                { edad--; }
                return edad;
            }
        }


        ~Alumno()
        {
            MessageBox.Show($"Legajo: {Legajo},Nombre: {Nombre},Apellido: {Apellido}");
        }

    }
}
