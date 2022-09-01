using System.Net.Http;
using System.Threading.Tasks;

namespace RJR.Client
{
    /// <summary>
    /// An interface which provides response parsing functionality. After calling the RJR API,
    /// this interface is used to parse the response's <see cref="HttpResponseMessage.Content"/>
    /// and return a <see cref="BuydownResponse"/>.
    /// </summary>
    public interface IResponseParser
    {
        /// <summary>
        /// Parses the content of a response and returns a <see cref="BuydownResponse"/>.
        /// </summary>
        /// <param name="responseContent">The content of the API response.</param>
        /// <returns>A <see cref="BuydownResponse"/> containing the data returned from the API.</returns>
        BuydownResponse ParseResponse(HttpContent responseContent);

        /// <summary>
        /// Parses the content of a response and returns a <see cref="BuydownResponse"/>.
        /// </summary>
        /// <param name="responseContent">The content of the API response.</param>
        /// <returns>A <see cref="BuydownResponse"/> containing the data returned from the API.</returns>
        Task<BuydownResponse> ParseResponseAsync(HttpContent responseContent);
    }
}