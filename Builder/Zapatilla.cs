using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class Zapatilla // PRODUCTO: el objeto complejo que se va a construir paso a paso
    {
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Suela { get; set; }
        public int Talle { get; set; }
        public decimal Precio { get; set; }

        public void Mostrar()
        {
            Console.WriteLine();
            Console.WriteLine("========= FICHA DE LA ZAPATILLA =========");
            Console.WriteLine($"Modelo : {Modelo}");
            Console.WriteLine($"Color  : {Color}");
            Console.WriteLine($"Suela  : {Suela}");
            Console.WriteLine($"Talle  : {Talle}");
            Console.WriteLine($"Precio : ${Precio:N0}");
            Console.WriteLine("=========================================");
        }
    }
}
