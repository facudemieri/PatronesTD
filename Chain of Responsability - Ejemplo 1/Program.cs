using System;
using System.Globalization;

namespace Chain_of_Responsability___Ejemplo_1
{
    internal class Program
    {
        static void Main(string[] args) //CLIENTE
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            decimal saldo = LeerMonto("Ingrese el saldo de la billetera virtual: ");
            decimal saldoCuenta = LeerMonto("Ingrese el saldo de la cuenta de débito: ");
            decimal limite = LeerMonto("Ingrese el límite disponible de la tarjeta de crédito: ");

            MedioDePago billetera = new SaldoBilletera(saldo);
            billetera.EstablecerSucesor(new TarjetaDebito(saldoCuenta))
                     .EstablecerSucesor(new TarjetaCredito(limite));

            int opcion;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1. Realizar pago");
                Console.WriteLine("0. Salir");
                Console.Write("Opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion) || (opcion != 0 && opcion != 1))
                {
                    Console.WriteLine("Opción inválida.");
                    continue;
                }

                if (opcion == 1)
                {
                    decimal monto;
                    do
                    {
                        monto = LeerMonto("Ingrese el monto a pagar: ");
                        if (monto <= 0)
                        {
                            Console.WriteLine("El monto debe ser mayor a 0.");
                        }
                    } while (monto <= 0);

                    Pago pago = new Pago(monto);
                    billetera.ManejarSolicitud(pago);
                    pago.Mostrar();
                }

            } while (opcion != 0);
        }

        // lee un monto por teclado (coma o punto como separador decimal) y repite hasta que sea válido y >= 0
        private static decimal LeerMonto(string mensaje)
        {
            Console.Write(mensaje);
            decimal monto;
            while (!TryParseMonto(Console.ReadLine(), out monto) || monto < 0)
            {
                Console.Write("Valor inválido. Ingrese un número mayor o igual a 0: ");
            }
            return monto;
        }

        // lee un monto por teclado (coma o punto como separador decimal) y repite hasta que sea válido y >= 0
        private static bool TryParseMonto(string texto, out decimal monto)
        {
            string normalizado = texto?.Replace('.', ',');
            const NumberStyles estilos = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;
            return decimal.TryParse(normalizado, estilos, CultureInfo.GetCultureInfo("es-AR"), out monto);
        }
    }
}
