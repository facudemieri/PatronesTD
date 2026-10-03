using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___Ejemplo_2
{
    public class ReporteHtmlBuilder : IReporteBuilder
    {
        private Reporte reporte = new Reporte();
        public void ConstruirCuerpo(List<string> items)
        {
            reporte.Agregar("  <ol>");
            foreach (string item in items)
            {
                reporte.Agregar($"    <li>{item}</li>");
            }
            reporte.Agregar("  </ol>");
            reporte.Agregar($"  <p>Cantidad de ítems: {items.Count}</p>");
        }

        public void ConstruirEncabezado(string titulo)
        {
            reporte.Agregar("<html>");
            reporte.Agregar("<body>");
            reporte.Agregar($"  <h1>{titulo}</h1>");
        }

        public void ConstruirPie()
        {
            reporte.Agregar($"  <footer>Generado el {DateTime.Now:dd/MM/yyyy HH:mm}</footer>");
            reporte.Agregar("</body>");
            reporte.Agregar("</html>");
        }

        public Reporte ObtenerReporte()
        {
            Reporte resultado = reporte;
            Reiniciar();
            return resultado;
        }

        public void Reiniciar()
        {
            reporte = new Reporte();
        }
    }
}
