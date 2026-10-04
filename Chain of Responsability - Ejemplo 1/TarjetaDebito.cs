using System;
using System.Globalization;

namespace Chain_of_Responsability___Ejemplo_1
{
    public class TarjetaDebito : MedioDePago // MANEJADOR CONCRETO: segundo eslabón de la cadena
    {
        private decimal saldoCuenta;

        public TarjetaDebito(decimal saldoCuenta)
        {
            this.saldoCuenta = saldoCuenta;
        }

        public override void ManejarSolicitud(Pago pago)
        {
            var cultura = CultureInfo.GetCultureInfo("es-AR");

            if (pago.Monto <= saldoCuenta)
            {
                saldoCuenta -= pago.Monto;
                pago.MarcarPagado("tarjeta de débito");
                Console.WriteLine($"Débito: pago de ${pago.Monto.ToString("N2", cultura)} cobrado con saldo de la cuenta.");
            }
            else
            {
                Console.WriteLine($"Débito: saldo insuficiente (${saldoCuenta.ToString("N2", cultura)}), pasa al siguiente medio.");
                base.ManejarSolicitud(pago);
            }
        }
    }
}
