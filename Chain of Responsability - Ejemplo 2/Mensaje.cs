using System;
using System.Collections.Generic;

namespace Chain_of_Responsability___Ejemplo_2
{
    public class Mensaje // SOLICITUD: es el mensaje que recorre la cadena de filtros
    {
        public string Autor { get; private set; }
        public string Texto { get; private set; }
        public bool Bloqueado { get; private set; }
        public string MotivoBloqueo { get; private set; }
        public List<string> Recorrido { get; private set; }

        // Crea el mensaje con su autor y texto, con el recorrido vacío
        public Mensaje(string autor, string texto)
        {
            Autor = autor;
            Texto = texto;
            Recorrido = new List<string>();
        }

        // Actualiza el texto si un filtro lo modificó y lo anota en el recorrido
        public void ReemplazarTexto(string nuevoTexto, string filtro)
        {
            if (nuevoTexto != Texto)
            {
                Texto = nuevoTexto;
                Recorrido.Add($"{filtro}: modificó el mensaje");
            }
            else
            {
                Recorrido.Add($"{filtro}: sin cambios");
            }
        }

        // Marca el mensaje como bloqueado para que no se publique y guarda el motivo
        public void Bloquear(string motivo)
        {
            Bloqueado = true;
            MotivoBloqueo = motivo;
            Recorrido.Add(motivo);
        }

        // Anota en el recorrido un filtro que revisó el mensaje sin modificarlo
        public void RegistrarPaso(string paso)
        {
            Recorrido.Add(paso);
        }

        // Muestra el autor, el texto final (o el motivo del bloqueo) y el recorrido
        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine($"Autor: {Autor}");
            Console.WriteLine(Bloqueado ? $"BLOQUEADO: {MotivoBloqueo}" : Texto);
            foreach (string paso in Recorrido)
            {
                Console.WriteLine($"  - {paso}");
            }
        }
    }
}
