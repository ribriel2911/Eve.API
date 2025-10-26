namespace Business.Entities.Views
{
    public class GetStatesView
    {
        /// <summary>
        /// Estado de la pantalla del gabinete.
        /// </summary>
        public bool CaseScreen { get; set; }

        /// <summary>
        /// Estado de las luces del gabinete.
        /// </summary>
        public bool CaseLights { get; set; }

        /// <summary>
        /// Estado de los ventiladores del gabinete.
        /// </summary>
        public bool CaseFans { get; set; }
    }
}
