using System.Text.RegularExpressions;

namespace Chain_of_Responsability___Ejemplo_2
{
    public class FiltroDatosPersonales : FiltroMensaje // MANEJADOR CONCRETO: último eslabón de la cadena
    {
        // Oculta los mails y teléfonos del mensaje y lo pasa al filtro siguiente.
        // Los mails van primero porque pueden tener 8 dígitos seguidos y se confundirían con un teléfono
        public override void ManejarSolicitud(Mensaje mensaje)
        {
            string textoNuevo = Regex.Replace(mensaje.Texto, @"[\w.+-]+@[\w-]+(?:\.[\w-]+)+", "[mail oculto]");
            textoNuevo = Regex.Replace(textoNuevo, @"\+?\d(?:[\s-]?\d){7,}", "[teléfono oculto]");

            mensaje.ReemplazarTexto(textoNuevo, "FiltroDatosPersonales");
            base.ManejarSolicitud(mensaje);
        }
    }
}
