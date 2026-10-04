using System.Text.RegularExpressions;

namespace Chain_of_Responsability___Ejemplo_2
{
    public class FiltroSpam : FiltroMensaje // MANEJADOR CONCRETO: primer eslabón de la cadena
    {
        private int enlacesMaximos;

        // Recibe la cantidad máxima de enlaces que se permite por mensaje
        public FiltroSpam(int enlacesMaximos)
        {
            this.enlacesMaximos = enlacesMaximos;
        }

        // Cuenta los enlaces del mensaje. Si supera el máximo lo bloquea y corta la cadena.Si no, lo pasa al filtro siguiente
        public override void ManejarSolicitud(Mensaje mensaje)
        {
            int cantidadEnlaces = Regex.Matches(mensaje.Texto, @"(https?://|www\.)\S+", RegexOptions.IgnoreCase).Count;

            if (cantidadEnlaces > enlacesMaximos)
            {
                mensaje.Bloquear($"Spam: {cantidadEnlaces} enlaces (máximo {enlacesMaximos})");
            }
            else
            {
                mensaje.RegistrarPaso("FiltroSpam: sin problemas");
                base.ManejarSolicitud(mensaje);
            }
        }
    }
}
