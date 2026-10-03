using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class ZapatillaBuilder : IZapatillaBuilder// CONSTRUCTOR CONCRETO: implementa cada paso y arma la zapatilla
    {
        private Zapatilla zapatilla = new Zapatilla();
        public void ArmarColor(string color)
        {
            zapatilla.Color = color;
        }

        public void ArmarModelo(string modelo)
        {
            zapatilla.Modelo = modelo;

            // Cada modelo tiene su precio base
            switch (modelo)
            {
                case "Running": zapatilla.Precio += 85000; break;
                case "Urbana": zapatilla.Precio += 70000; break;
                case "Skate": zapatilla.Precio += 78000; break;
            }
        }

        public void ArmarSuela(string suela)
        {
            zapatilla.Suela = suela;

            // Algunas suelas tienen recargo
            switch (suela)
            {
                case "Gel": zapatilla.Precio += 15000; break;
                case "Plataforma": zapatilla.Precio += 10000; break;
            }
        }

        public void ArmarTalle(int talle)
        {
            if (talle < 35 || talle > 46)
            {
                throw new ArgumentException("El talle debe estar entre 35 y 46.");
            }

            zapatilla.Talle = talle;
        }

        public Zapatilla ObtenerZapatilla()
        {
            // valido para que no se entregue la zapatilla incompleta
            if (zapatilla.Modelo == null || zapatilla.Color == null || zapatilla.Suela == null || zapatilla.Talle == 0)
            {
                throw new InvalidOperationException("La zapatilla está incompleta.");
            }

            Zapatilla resultado = zapatilla;
            Reiniciar(); // el builder queda listo para armar otra
            return resultado;
        }

        public void Reiniciar()
        {
            zapatilla = new Zapatilla();
        }
    }
}
