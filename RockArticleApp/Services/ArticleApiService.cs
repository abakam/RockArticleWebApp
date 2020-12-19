using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RockArticleApp.Models;
using RockArticleApp.Models.Resources;
using RockArticleApp.Utilities;

namespace RockArticleApp.Services
{
    public class ArticleApiService : IArticleApiService
    {
        private readonly ILogger<ArticleApiService> _logger;
        private readonly HttpClient _httpClient;
        private EnvironmentVariableKeys _environmentVariableKeys;
        private readonly string _apiBaseUrl;

        public ArticleApiService(ILogger<ArticleApiService> logger, HttpClient httpClient, EnvironmentVariableKeys environmentVariableKeys)
        {
            _environmentVariableKeys = environmentVariableKeys;
            _logger = logger;
            _httpClient = httpClient;
            _apiBaseUrl = Environment.GetEnvironmentVariable(_environmentVariableKeys.ArticleApiBaseUrl);
            _httpClient.BaseAddress = new Uri(_apiBaseUrl);
        }

        public async Task<ArticleLike> GetArticleLikesAsync(string articleId)
        {
            return new ArticleLike { ArticleId = articleId, HasBeenLiked = false, ArticleLikesCount = new Random().Next(1000, 10000) };
        }

        public async Task<ArticleLike> LikeArticleAsync(string articleId)
        {
            return new ArticleLike { ArticleId = articleId, ArticleLikesCount = new Random().Next(1000, 10000) };
        }

        public async Task<IEnumerable<ArticleResource>> ArticleListAsync()
        {
           
            return new List<ArticleResource> {
                new ArticleResource
                {
                    ArticleId = Guid.NewGuid().ToString().Replace("-", ""),
                    ArticleTitle = "Like Button Demo using Razor Component: Aricle has been liked by user",
                    ArticleLikesCount = new Random().Next(1000, 10000),
                    HasBeenLiked = true,
                    ArticleContentLocation = "https://gist.github.com/abakam/508a62f7ad3c2796d72f818e37ac138e.js",

                },
                new ArticleResource
                {
                    ArticleId = Guid.NewGuid().ToString().Replace("-", ""),
                    ArticleTitle = "Like Button Demo using Razor Component: Aricle has not been liked by user",
                    ArticleLikesCount = new Random().Next(1000, 10000),
                    HasBeenLiked = false,
                    ArticleContentLocation = "https://gist.github.com/abakam/508a62f7ad3c2796d72f818e37ac138e.js",

                }
            };

        }
    }
}
