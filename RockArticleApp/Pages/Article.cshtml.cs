﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RockArticleApp.Models;
using RockArticleApp.Services;

namespace RockArticleApp.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly ILogger<ArticleModel> _logger;
        private readonly IArticleApiService _articleApiService;

        public ArticleModel(IArticleApiService articleApiService, ILogger<ArticleModel> logger)
        {
            _articleApiService = articleApiService;
            _logger = logger;
        }

        [BindProperty(SupportsGet = true)]
        public string ArticleId { get; set; }
        public long ArticleLikesCount { get; set; }
        public bool HasBeenLiked { get; set; }
        public string ArticleContentLocation { get; set; }

        public async Task OnGetAsync(string articleId)
        {
            try
            {
                var articleLikes = await _articleApiService.GetArticleLikesAsync(articleId);

                ArticleLikesCount = articleLikes.ArticleLikesCount;
                HasBeenLiked = articleLikes.HasBeenLiked;
               
            }
            catch(Exception ex)
            {
                _logger.LogError($"Retrieving article likes failed: {ex.Message}", ex);
            }
            finally
            {
                ArticleId = articleId;
            }
        }

        public async Task<JsonResult> OnGetLikeArticleAsync()
        {
            try
            {
                var articleLikes = await _articleApiService.LikeArticleAsync(ArticleId);

                return new JsonResult(articleLikes);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Updating article likes failed: {ex.Message}", ex);
                return new JsonResult(new ArticleLike());
            }
        }
    }
}
