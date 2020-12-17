using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RockArticleApp.Models;
using RockArticleApp.Utils;

namespace RockArticleApp.Services
{
    public class ArticleApiService : IArticleApiService
    {
        private readonly ILogger<ArticleApiService> _logger;
        private readonly HttpClient _httpClient;
        private EnvironmentVariables _environmentVariables;
        private readonly string _apiBaseUrl;

        public ArticleApiService(ILogger<ArticleApiService> logger, HttpClient httpClient, EnvironmentVariables environmentVariables)
        {
            _environmentVariables = environmentVariables;
            _logger = logger;
            _httpClient = httpClient;
            _apiBaseUrl = Environment.GetEnvironmentVariable(_environmentVariables.ArticleApiBaseUrl);
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
        }

        public async Task<ArticleLike> GetArticleLikesAsync(string articleId)
        {
            
            var apiGetLikePath = Environment.GetEnvironmentVariable(_environmentVariables.ArticleApiGetLikesPath);
            var request = new HttpRequestMessage(HttpMethod.Get, apiGetLikePath);

            var response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    return await response.Content.ReadFromJsonAsync<ArticleLike>();
                }
                catch (NotSupportedException ex)
                {
                    _logger.LogError("Failed to get article likes: Not supported content type", ex);
                }
                catch (JsonException ex) 
                {
                    _logger.LogError("Failed to get article likes: Invalid Json", ex);
                }
                
            }
          
            return new ArticleLike { ArticleId = articleId, ArticleLikesCount = new Random().Next(1000, 10000) };
        }

        public async Task<ArticleLike> LikeArticleAsync(string articleId)
        {
            var apiLikeArticlePath = Environment.GetEnvironmentVariable(_environmentVariables.ArticleApiLikeArticlePath);
           

            var postResponse = await _httpClient.PostAsJsonAsync(apiLikeArticlePath, new LikeArticlePayload { ArticleId = articleId });


            if (postResponse.IsSuccessStatusCode)
            {
                try
                {
                    return await postResponse.Content.ReadFromJsonAsync<ArticleLike>();
                }
                catch (NotSupportedException ex)
                {
                    _logger.LogError("Failed to get article likes: Not supported content type", ex);
                }
                catch (JsonException ex)
                {
                    _logger.LogError("Failed to get article likes: Invalid Json", ex);
                }
            }

            return new ArticleLike { ArticleId = articleId, ArticleLikesCount = new Random().Next(1000, 10000) };
        }
    }
}
