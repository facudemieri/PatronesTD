using System;
using System.Globalization;

namespace Chain_of_Responsability___Ejemplo_1
{
    public class Pago // SOLICITUD: es el pago que recorre la cadena de medios
    {
        public decimal Monto { get; private set; }
        public string PagadoCon { get; private set; }

        public Pago(decimal monto)
        {
            Monto = monto;
        }

        public void MarcarPagado(string medio)
        {
            PagadoCon = medio;
        }

        public bool EstaPago()
        {
            return PagadoCon != null;
        }

        public void Mostrar()
        {
            var cultura = CultureInfo.GetCultureInfo("es-AR");

            if (EstaPago())
            {
                Console.WriteLine($"Pago de ${Monto.ToString("N2", cultura)} cobrado con {PagadoCon}.");
            }
            else
            {
                Console.WriteLine($"Pago de ${Monto.ToString("N2", cultura)} rechazado: ningún medio pudo cubrirlo.");
            }
        }
    }
}
