using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace RJR.Client
{
    public class RJRClient
    {
        string _authToken;

        public RJRClient(Configuration configuration, IAuthenticator authenticator, IResponseParser responseParser)
        {
            Configuration = configuration;
            Authenticator = authenticator;
            Parser = responseParser;
        }

        public RJRClient(IAuthenticator authenticator, IResponseParser responseParser) :
            this(Configuration.DefaultConfiguration, authenticator, responseParser) { }


        public bool IsAuthenticated { get; private set; }
        public IAuthenticator Authenticator { get; }
        public Configuration Configuration { get; }
        public IResponseParser Parser { get; }
        
        public bool ThrowOnError { get; set; } = true;


        public BuydownResponse GetData(string cycleCode)
        {
            using var httpClient = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, GetParameterizedUrl(Configuration, cycleCode));
            SetHeaders(request, Configuration);
            using var response = httpClient.Send(request);
            if (IsResponseSuccessful(response))
                return Parser.ParseResponse(response.Content);
            return null;
        }

        public async Task<BuydownResponse> GetDataAsync(string cycleCode)
        {
            using var httpClient = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Get, GetParameterizedUrl(Configuration, cycleCode));
            SetHeaders(request, Configuration);
            using var response = await httpClient.SendAsync(request);
            if (IsResponseSuccessful(response))
                return await Parser.ParseResponseAsync(response.Content);
            return null;
        }

        bool IsResponseSuccessful(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return true;
         
            if (ThrowOnError)
                response.EnsureSuccessStatusCode();

            return false;
        }

        void SetHeaders(HttpRequestMessage request, Configuration configuration)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", configuration.SubscriptionKey);
            request.Headers.Add("Authorization", GetAuthenticationToken());
        }

        string GetAuthenticationToken()
        {
            if (!IsAuthenticated)
                Authenticate();
            return $"Bearer {_authToken}";
        }

        void Authenticate()
        {
            _authToken = Authenticator.Authenticate();
            IsAuthenticated = true;
        }

        static string GetParameterizedUrl(Configuration configuration, string cycleCode)
        {
            var uriBuilder = new UriBuilder(configuration.BuydownEndpoint);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Add("AccountNumber", configuration.AccountNumber);
            query.Add("OperatingCompanyCode", configuration.OperatingCompanyCode);
            query.Add("CycleCode", cycleCode);
            uriBuilder.Query = query.ToString();
            return uriBuilder.ToString();
        }
    }
}