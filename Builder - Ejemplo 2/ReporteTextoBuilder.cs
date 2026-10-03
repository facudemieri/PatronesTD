using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder___Ejemplo_2
{
    public class ReporteTextoBuilder : IReporteBuilder //CONSTRUCTOR CONCRETO 1: arma el reporte en texto plano
    {
        private Reporte reporte = new Reporte();
        public void ConstruirCuerpo(List<string> items)
        {
            for (int i = 0; i < items.Count; i++)
            {
                reporte.Agregar($"  {i + 1}. {items[i]}");
            }
            reporte.Agregar("----------------------------------------");
            reporte.Agregar($"  Cantidad de ítems: {items.Count}");
        }

        public void ConstruirEncabezado(string titulo)
        {
            reporte.Agregar("========================================");
            reporte.Agregar("  " + titulo.ToUpper());
            reporte.Agregar("========================================");
        }

        public void ConstruirPie()
        {
            reporte.Agregar($"  Generado el {DateTime.Now:dd/MM/yyyy HH:mm}");
            reporte.Agregar("========================================");
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
