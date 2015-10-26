using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppContratacionColecciones.Clases;
using AppContratacionColecciones.Excepciones;

namespace AppContratacionColecciones
{
    class Program
    {
        public static List<Empleado> Empleados { get; set; } = new List<Empleado>();

        static void Main(string[] args)
        {
            
            do
            {
                Console.Clear();
                var menu = Menu();
                Console.Clear();

                switch (menu)
                {
                    case 1: 
                        Alta();
                        break;
                    case 2:
                        Listar();
                        break;
                }

            } while (true);
        }

        public static void Listar()
        {
            Console.WriteLine("LISTADO DE EMPLEADOS\n");
            if (Empleados.Count == 0)
                Console.WriteLine("No existen empleados todavía...\n");
            foreach (var e in Empleados)
            {
                Console.WriteLine(e);
            }

            Console.Write("\nPulse ENTER para continuar.");
            Console.Read();
        }

        public static void Alta()
        {
            int edad;
            Estudios est;
            Puestos pue;
            var creado = false;

            Console.WriteLine("ALTA DE EMPLEADO\n");
            Console.Write("Nombre: ");
            var nom = Console.ReadLine();

            do
            {
                Console.Write("Edad: ");
            } while (!int.TryParse(Console.ReadLine(), out edad));

            do
            {
                Console.Clear();
                Console.WriteLine("ALTA DE EMPLEADO\n");
                Console.WriteLine("{0}) {1}", Estudios.Basico.GetHashCode(), Estudios.Basico);
                Console.WriteLine("{0}) {1}", Estudios.Medio.GetHashCode(), Estudios.Medio);
                Console.WriteLine("{0}) {1}", Estudios.Superior.GetHashCode(), Estudios.Superior);
                Console.WriteLine("{0}) {1}", Estudios.Doctor.GetHashCode(), Estudios.Doctor);
                Console.Write("Nivel de estudios: ");

            } while (!Enum.TryParse(Console.ReadLine(), out est) || !Enum.IsDefined(typeof(Estudios), est));

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("ALTA DE EMPLEADO\n");
                    Console.WriteLine("{0}) {1}", Puestos.Programador.GetHashCode(), Puestos.Programador);
                    Console.WriteLine("{0}) {1}", Puestos.Analista.GetHashCode(), Puestos.Analista);
                    Console.WriteLine("{0}) {1}", Puestos.DirectorProyectos.GetHashCode(), Puestos.DirectorProyectos);
                    Console.WriteLine("{0}) {1}", Puestos.DirectorIT.GetHashCode(), Puestos.DirectorIT);
                    Console.Write("Puesto a ocupar: ");
                    
                } while (!Enum.TryParse(Console.ReadLine(), out pue) || !Enum.IsDefined(typeof(Puestos),pue));

                try
                {
                    Empleados.Add(new Empleado() { Edad = edad, Estudios = est, Puesto = pue, Nombre = nom });
                    Console.WriteLine("Creado.");
                    creado = true;
                }
                catch (EstudiosInsuficientesException e)
                {
                    Console.WriteLine("\n"+e.Message);
                    Console.Read();
                }

            } while (!creado); 
        }

        public static int Menu()
        {
            do
            {
                Console.WriteLine("Elija una opción: \n" +
                                  "1) Alta de empleado\n" +
                                  "2) Listar empleados\n");
                int res;
                if (int.TryParse(Console.ReadLine(), out res))
                    if ((res != 1) || (res != 2))
                        return res;

                Console.Clear();

            } while (true);
            
        }

    }

}
