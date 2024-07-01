using Kata.Application.Order.Interfaces;
using Kata.Application.Order.Model;
using System.Text.Json;

namespace Kata.Infrastructure.Clients
{
    public class OrderHttpClient : IOrderHttpClient
    {
        private readonly HttpClient _httpClient;
        public OrderHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<OrderResponseDto> GetOrdersAsync(CancellationToken cancellationToken)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"orders");
            var responseMessage = await _httpClient.SendAsync(requestMessage);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}");
            }

            return await JsonSerializer.DeserializeAsync<OrderResponseDto>(await responseMessage.Content.ReadAsStreamAsync(cancellationToken));
        }
    }
}
