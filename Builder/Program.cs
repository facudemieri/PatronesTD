using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    internal class Program
    {
        static void Main(string[] args) //CLIENTE
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            string[] modelos = { "Running", "Urbana", "Skate" };
            string[] colores = { "Negro", "Blanco", "Rojo", "Azul" };
            string[] suelas = { "Goma", "Gel", "Plataforma" };

            IZapatillaBuilder builder = new ZapatillaBuilder();
            AsesorDeVentas asesor = new AsesorDeVentas(builder);

            int opcion;
            do
            {
                Console.WriteLine();
                Console.WriteLine("===== ZAPATILLAS PERSONALIZADAS =====");
                Console.WriteLine("1. Running prearmada (Negro, suela Gel)");
                Console.WriteLine("2. Urbana prearmada (Blanco, suela Goma)");
                Console.WriteLine("3. Armar a medida");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = LeerOpcion(0, 3);

                if (opcion == 0) break;

                if (opcion == 1 || opcion == 2)
                {
                    // El DIRECTOR arma la zapatilla con su receta
                    Console.Write("Ingrese el talle (35 a 46): ");
                    int talle = LeerOpcion(35, 46);

                    if (opcion == 1) asesor.ArmarRunning(talle);
                    else asesor.ArmarUrbana(talle);
                }
                else
                {
                    // El CLIENTE usa el BUILDER directamente, paso a paso
                    builder.Reiniciar();

                    Console.WriteLine("Modelos: 1. Running  2. Urbana  3. Skate");
                    Console.Write("Elija el modelo: ");
                    builder.ArmarModelo(modelos[LeerOpcion(1, 3) - 1]);

                    Console.WriteLine("Colores: 1. Negro  2. Blanco  3. Rojo  4. Azul");
                    Console.Write("Elija el color: ");
                    builder.ArmarColor(colores[LeerOpcion(1, 4) - 1]);

                    Console.WriteLine("Suelas: 1. Goma  2. Gel (+$15.000)  3. Plataforma (+$10.000)");
                    Console.Write("Elija la suela: ");
                    builder.ArmarSuela(suelas[LeerOpcion(1, 3) - 1]);

                    Console.Write("Ingrese el talle (35 a 46): ");
                    builder.ArmarTalle(LeerOpcion(35, 46));
                }

                // En ambos casos el producto se obtiene del BUILDER
                Zapatilla zapatilla = builder.ObtenerZapatilla();
                zapatilla.Mostrar();

            } while (opcion != 0);

            Console.WriteLine("¡Gracias por su compra!");
        }

        // lee un numero entero por teclado y valida que esté en el rango
        private static int LeerOpcion(int min, int max)
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
            {
                Console.Write($"Valor inválido. Ingrese un número entre {min} y {max}: ");
            }
            return valor;
        }
    }
}
