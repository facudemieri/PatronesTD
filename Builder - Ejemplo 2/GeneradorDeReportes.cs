using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___Ejemplo_2
{
    public class GeneradorDeReportes // DIRECTOR: siempre ejecuta los mismos pasos en el mismo orden sin saber en que formato
        //se esta armando el reporte
    {
        private IReporteBuilder builder;
        public GeneradorDeReportes(IReporteBuilder builder)
        {
            this.builder = builder;
        }

        public void Generar(string titulo, List<string> items)
        {
            builder.Reiniciar();
            builder.ConstruirEncabezado(titulo);
            builder.ConstruirCuerpo(items);
            builder.ConstruirPie();
        }
    }
}
