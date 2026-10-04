using System;
using System.Globalization;

namespace Chain_of_Responsability___Ejemplo_1
{
    public class TarjetaCredito : MedioDePago // MANEJADOR CONCRETO: último eslabón de la cadena
    {
        private decimal limiteDisponible;

        public TarjetaCredito(decimal limiteDisponible)
        {
            this.limiteDisponible = limiteDisponible;
        }

        public override void ManejarSolicitud(Pago pago)
        {
            var cultura = CultureInfo.GetCultureInfo("es-AR");

            if (pago.Monto <= limiteDisponible)
            {
                limiteDisponible -= pago.Monto;
                pago.MarcarPagado("tarjeta de crédito");
                Console.WriteLine($"Crédito: pago de ${pago.Monto.ToString("N2", cultura)} cobrado con límite disponible.");
            }
            else
            {
                Console.WriteLine($"Crédito: límite insuficiente (${limiteDisponible.ToString("N2", cultura)}), pasa al siguiente medio.");
                base.ManejarSolicitud(pago);
            }
        }
    }
}
