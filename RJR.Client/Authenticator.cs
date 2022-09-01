using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RJR.Client
{
    public class Authenticator : IAuthenticator
    {
        readonly string _id;
        readonly string _password;

        public Authenticator(string id, string password, Configuration configuration)
        {
            _id = id;
            _password = password;

            Configuration = configuration;
        }

        public Configuration Configuration { get; }

        public bool ThrowOnError { get; set; } = true;

        public async Task<string> AuthenticateAsync()
        {
            using var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, Configuration.AuthenticationEndpoint);
            SetHeaders(request);
            SetContent(request);

            using var response = await client.SendAsync(request);
            if (IsResponseSuccessful(response))
                return await ParseResponseAsync(response.Content);

            return null;
        }

        public string Authenticate()
        {
            using var client = new HttpClient();
            using var request = new HttpRequestMessage(HttpMethod.Post, Configuration.AuthenticationEndpoint);
            SetHeaders(request);
            SetContent(request);

            using var response = client.Send(request);
            if (IsResponseSuccessful(response))
                return ParseResponse(response.Content);

            return null;
        }

        void SetHeaders(HttpRequestMessage request)
        {
            request.Headers.Add("Ocp-Apim-Subscription-Key", Configuration.SubscriptionKey);
        }

        void SetContent(HttpRequestMessage request)
        {
            request.Content = new FormUrlEncodedContent(GetRequestContent());
        }

        string ParseResponse(HttpContent responseContent)
        {
            var json = responseContent.ReadAsStringAsync().Result;
            var response = JsonConvert.DeserializeObject<AuthResponse>(json);
            return response.access_token;
        }

        async Task<string> ParseResponseAsync(HttpContent responseContent)
        {
            var json = await responseContent.ReadAsStringAsync();
            var response = JsonConvert.DeserializeObject<AuthResponse>(json);
            return response.access_token;
        }
        
        bool IsResponseSuccessful(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return true;

            if (ThrowOnError)
                response.EnsureSuccessStatusCode();

            return false;
        }

        Dictionary<string, string> GetRequestContent()
        {
            return new Dictionary<string, string>()
            {
                { "client_id", _id },
                { "client_secret", _password },
                { "grant_type", "client_credentials" },
                { "scope", Configuration.Scope }
            };
        }

        class AuthResponse
        {
            public string access_token { get; set; }
        }
    }
}