namespace DCXAirTest.API.Helpers
{
    public class AppSettings
    {
        /// <summary>
        /// Obtiene y/o establece los orgenes cruzados.
        /// </summary>
        public string[] OriginCors { get; set; }

        /// <summary>
        /// Obtiene y/o establece el secret para el token.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Obtiene y/o establece el issuer para el token.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Obtiene y/o establece el audience para el token.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Obtiene y/o establece el tiempo de vida para el token.
        /// </summary>
        public int Expires { get; set; }

        /// <summary>
        /// Obtiene y/o establece la versión de la aplicación.
        /// </summary>
        public string Version { get; set; }
    }
}
