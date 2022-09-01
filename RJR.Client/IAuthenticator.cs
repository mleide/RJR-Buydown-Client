namespace RJR.Client
{
    public interface IAuthenticator
    {
        /// <summary>
        /// Authenticates against the API and returns a bearer token.
        /// </summary>
        /// <returns></returns>
        public string Authenticate();
    }
}