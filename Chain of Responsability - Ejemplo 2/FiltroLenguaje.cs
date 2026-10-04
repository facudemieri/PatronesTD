using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Chain_of_Responsability___Ejemplo_2
{
    public class FiltroLenguaje : FiltroMensaje // MANEJADOR CONCRETO: segundo eslabón de la cadena
    {
        private List<string> palabrasProhibidas = new List<string>();

        // Agrega una palabra a la lista de prohibidas, sin repetir ni cargar vacías
        public void AgregarPalabra(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra))
            {
                Console.WriteLine("No se ingresó ninguna palabra.");
                return;
            }

            string palabraNormalizada = palabra.Trim().ToLower();
            if (palabrasProhibidas.Contains(palabraNormalizada))
            {
                Console.WriteLine("La palabra \"" + palabraNormalizada + "\" ya estaba en la lista.");
                return;
            }

            palabrasProhibidas.Add(palabraNormalizada);
            Console.WriteLine("Palabra agregada: " + palabraNormalizada);
        }

        // Reemplaza por asteriscos cada palabra prohibida que aparezca en el mensaje y lo pasa al filtro siguiente
        public override void ManejarSolicitud(Mensaje mensaje)
        {
            string textoNuevo = mensaje.Texto;

            foreach (string palabra in palabrasProhibidas)
            {
                string patron = $@"\b{Regex.Escape(palabra)}\b";
                string asteriscos = new string('*', palabra.Length);
                textoNuevo = Regex.Replace(textoNuevo, patron, asteriscos, RegexOptions.IgnoreCase);
            }

            mensaje.ReemplazarTexto(textoNuevo, "FiltroLenguaje");
            base.ManejarSolicitud(mensaje);
        }
    }
}
