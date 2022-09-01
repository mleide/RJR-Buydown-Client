using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RJR.Client
{
    public class JsonResponseParser : IResponseParser
    {
        public BuydownResponse ParseResponse(HttpContent responseContent)
        {
            return ParseJson(responseContent.ReadAsStringAsync().Result);
        }

        public async Task<BuydownResponse> ParseResponseAsync(HttpContent responseContent)
        {
            return await ParseJsonAsync(await responseContent.ReadAsStringAsync());
        }

        BuydownResponse ParseJson(string json)
        {
            return JsonConvert.DeserializeObject<BuydownResponse>(json);
        }

        Task<BuydownResponse> ParseJsonAsync(string json)
        {
            return Task.Run(() => JsonConvert.DeserializeObject<BuydownResponse>(json));
        }
    }
}