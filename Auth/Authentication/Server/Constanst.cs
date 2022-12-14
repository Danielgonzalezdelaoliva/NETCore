namespace Server
{
    public static class Constanst
    {
        /// <summary>
        /// Emisor
        /// </summary>
        public const string Issuer = Audiance;
        public const string Audiance = "https://localhost:44353/";
        public const string Secret = "esto es una clave secreta para poder permitir autetificarse";
    }
}
