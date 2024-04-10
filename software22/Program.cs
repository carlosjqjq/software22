using System;
using System.Collections.Generic;

namespace RegistroEmpresa
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Trabajador> empleados = new List<Trabajador>();

            while (true)
            {
                Console.WriteLine("Ingrese el nombre del trabajador (o 'salir' para terminar):");
                string nombre = Console.ReadLine();

                if (nombre.ToLower() == "salir")
                    break;

                Console.WriteLine("Ingrese los apellidos:");
                string apellidos = Console.ReadLine();

                Console.WriteLine("Ingrese el sueldo bruto:");
                double sueldoBruto;
                while (!double.TryParse(Console.ReadLine(), out sueldoBruto) || sueldoBruto <= 0)
                {
                    Console.WriteLine("Ingrese un sueldo bruto válido (mayor a cero):");
                }

                Console.WriteLine("Ingrese la categoría del trabajador (A/B/C):");
                char categoria;
                while (!char.TryParse(Console.ReadLine().ToUpper(), out categoria) || (categoria != 'A' && categoria != 'B' && categoria != 'C'))
                {
                    Console.WriteLine("Ingrese una categoría válida (A/B/C):");
                }

                Trabajador empleado = new Trabajador(nombre, apellidos, sueldoBruto, categoria);
                empleados.Add(empleado);
            }

            Console.WriteLine("Lista de empleados ingresados:");
            double totalSueldosNetos = 0;
            foreach (Trabajador empleado in empleados)
            {
                Console.WriteLine($"{empleado.Nombre} {empleado.Apellidos} - Sueldo Bruto: {empleado.SueldoBruto} - Monto Aumento: {empleado.MontoAumento} - Sueldo Neto: {empleado.SueldoNeto}");
                totalSueldosNetos += empleado.SueldoNeto;
            }

            Console.WriteLine($"Monto total de Sueldos Netos: {totalSueldosNetos}");
        }
    }

    class Trabajador
    {
        public string Nombre { get; }
        public string Apellidos { get; }
        public double SueldoBruto { get; }
        public char Categoria { get; }
        public double MontoAumento { get; }
        public double SueldoNeto { get; }

        public Trabajador(string nombre, string apellidos, double sueldoBruto, char categoria)
        {
            Nombre = nombre;
            Apellidos = apellidos;
            SueldoBruto = sueldoBruto;
            Categoria = categoria;
            MontoAumento = CalcularMontoAumento();
            SueldoNeto = SueldoBruto + MontoAumento;
        }

        private double CalcularMontoAumento()
        {
            double porcentajeAumento = 0;

            if (SueldoBruto <= 1000)
                porcentajeAumento = 0.1;
            else if (SueldoBruto <= 2000)
                porcentajeAumento = 0.2;
            else if (SueldoBruto <= 4000)
                porcentajeAumento = 0.3;
            else
                porcentajeAumento = 0.4;

            return porcentajeAumento * SueldoBruto;
        }
    }
}

