using System;
using System.Collections.Generic;

namespace Chain_of_Responsability___Ejemplo_2
{
    internal class Program
    {
        private static List<Mensaje> publicados = new List<Mensaje>();

        //CLIENTE: Arma la cadena de filtros y maneja el menú; los mensajes se envían solo al primer filtro
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.Write("Ingrese la cantidad máxima de enlaces permitidos por mensaje: ");
            int enlacesMaximos = LeerOpcion();

            FiltroLenguaje filtroLenguaje = new FiltroLenguaje();
            FiltroMensaje cadena = new FiltroSpam(enlacesMaximos);
            cadena.EstablecerSucesor(filtroLenguaje)
                  .EstablecerSucesor(new FiltroDatosPersonales());

            int opcion;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Publicar mensaje");
                Console.WriteLine("2. Agregar palabra prohibida");
                Console.WriteLine("3. Ver mensajes publicados");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");
                opcion = LeerOpcion();

                switch (opcion)
                {
                    case 1:
                        string autor = LeerTexto("Autor: ");
                        string texto = LeerTexto("Mensaje: ");
                        Mensaje mensaje = new Mensaje(autor, texto);
                        cadena.ManejarSolicitud(mensaje);
                        mensaje.Mostrar();
                        if (!mensaje.Bloqueado)
                        {
                            publicados.Add(mensaje);
                        }
                        break;

                    case 2:
                        string palabra = LeerTexto("Palabra prohibida: ");
                        filtroLenguaje.AgregarPalabra(palabra);
                        break;

                    case 3:
                        if (publicados.Count == 0)
                        {
                            Console.WriteLine("No hay mensajes publicados.");
                        }
                        else
                        {
                            foreach (Mensaje publicado in publicados)
                            {
                                publicado.Mostrar();
                            }
                        }
                        break;

                    case 0:
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (opcion != 0);
        }

        // Lee un número entero mayor o igual a 0. Si no es válido, le pide que ingrese otro.
        private static int LeerOpcion()
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                Console.Write("Valor inválido. Ingrese un número entero mayor o igual a 0: ");
            }
            return valor;
        }

        // Lee un texto y le pide un nuevo ingreso si esta vacío
        private static string LeerTexto(string mensaje)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(texto))
            {
                Console.Write("El texto no puede estar vacío. " + mensaje);
                texto = Console.ReadLine();
            }
            return texto;
        }
    }
}
