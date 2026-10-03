using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___Ejemplo_2
{
    public class Reporte //PRODUCTO : el reporte qque se va armando por partes
    {
        private string contenido = "";

        public void Agregar(string texto)
        {
            contenido += texto + Environment.NewLine;
        }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine(contenido);
        }
    }
}
