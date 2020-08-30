using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace DaprDemoApp.Data
{
    /// <summary>
    /// Service to handle user feedback
    /// </summary>
    public class FeedbackService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="logger"></param>
        public FeedbackService(IHttpClientFactory httpClientFactory, ILogger<FeedbackService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        /// <summary>
        /// SubmitFeedback - Accepts user feedback and publishes User
        //  message to DAPR Sidecar pub-sub endpoint
        /// </summary>
        /// <param name="userData"></param>
        /// <returns></returns>
        public async Task<bool> SubmitFeedback(UserFeedback userData)
        {
            var client = _httpClientFactory.CreateClient();

            HttpContent httpContent = new StringContent(JsonSerializer.Serialize(userData));
            _logger.LogInformation(JsonSerializer.Serialize(userData));

            //DAPR PUB-SUB URL 
            //http://localhost:3500/v1.0/publish/<pub-sub-component-name>/<topic-name>

            var response = await client.PostAsync("http://localhost:3500/v1.0/publish/messagebus/feedback",
                                 httpContent);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation($"Posted message successfuly - {userData.FirstName}");
                return true;
            }

            _logger.LogError("Something went wrong");
            return false;
        }
    }
}
