using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public class AsesorDeVentas //DIRECTOR: conoce las "recetas" y el orden de los pasos
    {
        private IZapatillaBuilder builder;

        public AsesorDeVentas(IZapatillaBuilder builder)
        {
            this.builder = builder;
        }

        public void ArmarRunning(int talle)
        {
            builder.Reiniciar();
            builder.ArmarModelo("Running");
            builder.ArmarColor("Negro");
            builder.ArmarSuela("Gel");
            builder.ArmarTalle(talle);
        }

        public void ArmarUrbana(int talle)
        {
            builder.Reiniciar();
            builder.ArmarModelo("Urbana");
            builder.ArmarColor("Blanco");
            builder.ArmarSuela("Goma");
            builder.ArmarTalle(talle);
        }
    }
}
