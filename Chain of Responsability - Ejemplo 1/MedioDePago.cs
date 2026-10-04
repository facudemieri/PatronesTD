namespace Chain_of_Responsability___Ejemplo_1
{
    public abstract class MedioDePago // MANEJADOR: declara la interfaz de la cadena
    {
        protected MedioDePago sucesor;

        public MedioDePago EstablecerSucesor(MedioDePago sucesor)
        {
            this.sucesor = sucesor;
            return sucesor;
        }

        public virtual void ManejarSolicitud(Pago pago)
        {
            if (sucesor != null)
            {
                sucesor.ManejarSolicitud(pago);
            }
        }
    }
}
