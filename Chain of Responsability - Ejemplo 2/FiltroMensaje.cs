namespace Chain_of_Responsability___Ejemplo_2
{
    public abstract class FiltroMensaje // MANEJADOR: declara la interfaz de la cadena
    {
        protected FiltroMensaje sucesor;

        // Enlaza el filtro siguiente y lo devuelve para poder encadenar las llamadas
        public FiltroMensaje EstablecerSucesor(FiltroMensaje sucesor)
        {
            this.sucesor = sucesor;
            return sucesor;
        }

        // Pasa el mensaje al filtro siguiente; si es el último, la cadena termina
        public virtual void ManejarSolicitud(Mensaje mensaje)
        {
            if (sucesor != null)
            {
                sucesor.ManejarSolicitud(mensaje);
            }
        }
    }
}
