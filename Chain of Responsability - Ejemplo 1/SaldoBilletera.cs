using System;
using System.Globalization;

namespace Chain_of_Responsability___Ejemplo_1
{
    public class SaldoBilletera : MedioDePago // MANEJADOR CONCRETO: primer eslabón de la cadena
    {
        private decimal saldo;

        public SaldoBilletera(decimal saldo)
        {
            this.saldo = saldo;
        }

        public override void ManejarSolicitud(Pago pago)
        {
            var cultura = CultureInfo.GetCultureInfo("es-AR");

            if (pago.Monto <= saldo)
            {
                saldo -= pago.Monto;
                pago.MarcarPagado("billetera virtual");
                Console.WriteLine($"Billetera: pago de ${pago.Monto.ToString("N2", cultura)} cobrado con saldo de la billetera.");
            }
            else
            {
                Console.WriteLine($"Billetera: saldo insuficiente (${saldo.ToString("N2", cultura)}), pasa al siguiente medio.");
                base.ManejarSolicitud(pago);
            }
        }
    }
}
