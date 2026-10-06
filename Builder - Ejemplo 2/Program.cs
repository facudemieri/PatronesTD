using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___Ejemplo_2
{
    internal class Program //CLIENTE
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string titulo = "";
            List<string> items = new List<string>();

            int opcion;
            do
            {
                Console.WriteLine();
                Console.WriteLine("===== GENERADOR DE REPORTES =====");
                Console.WriteLine("1. Cargar datos del reporte");
                Console.WriteLine("2. Generar reporte en TEXTO");
                Console.WriteLine("3. Generar reporte en HTML");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = LeerOpcion(0, 3);

                if (opcion == 1)
                {
                    titulo = LeerTexto("Título del reporte: ");

                    Console.Write("¿Cuántos ítems va a cargar? (1 a 10): ");
                    int cantidad = LeerOpcion(1, 10);

                    items.Clear();
                    for (int i = 1; i <= cantidad; i++)
                    {
                        items.Add(LeerTexto($"Ítem {i}: "));
                    }
                    Console.WriteLine("Datos cargados correctamente.");
                }
                else if (opcion == 2 || opcion == 3)
                {
                    if (items.Count == 0)
                    {
                        Console.WriteLine("Primero debe cargar los datos (opción 1).");
                        continue;
                    }

                    // Lo unico que cambia es el BUILDER que se elige
                    IReporteBuilder builder;
                    if (opcion == 2) builder = new ReporteTextoBuilder();
                    else builder = new ReporteHtmlBuilder();

                    // El DIRECTOR ejecuta siempre los mismos pasos
                    GeneradorDeReportes generador = new GeneradorDeReportes(builder);
                    generador.Generar(titulo, items); 

                    // El producto se obtiene del BUILDER
                    Reporte reporte = builder.ObtenerReporte();
                    reporte.Mostrar();
                }

            } while (opcion != 0);
        }

        // Lee un numero entero por teclado y valida que este en el rango
        private static int LeerOpcion(int min, int max)
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
            {
                Console.Write($"Valor inválido. Ingrese un número entre {min} y {max}: ");
            }
            return valor;
        }

        // Lee un texto por teclado y valida que no este vacio
        private static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(texto))
            {
                Console.Write("No puede estar vacio. " + mensaje);
                texto = Console.ReadLine();
            }
            return texto.Trim();
        
        }
    }
}
