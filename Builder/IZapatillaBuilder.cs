using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface IZapatillaBuilder // BUILDER: declara los pasos para construir cada parte del producto
    {
        void Reiniciar();
        void ArmarModelo(string modelo);
        void ArmarColor(string color);
        void ArmarSuela(string suela);
        void ArmarTalle(int talle);
        Zapatilla ObtenerZapatilla();
    }
}
