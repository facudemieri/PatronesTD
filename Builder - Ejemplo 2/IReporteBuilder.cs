using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___Ejemplo_2
{
    public interface IReporteBuilder //BUILDER :  los mismos pasos sirven para cualquiera de los dos formatos
    {
        void Reiniciar();
        void ConstruirEncabezado(string titulo);
        void ConstruirCuerpo(List<string> items);
        void ConstruirPie();
        Reporte ObtenerReporte();
    }
}
