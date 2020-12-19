using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RockArticleApp.Models.Resources;
using RockArticleApp.Services;

namespace RockArticleApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IArticleApiService _articleApiService;
        public IEnumerable<ArticleResource> Articles { get; set; } 

        public IndexModel(IArticleApiService articleApiService, ILogger<IndexModel> logger)
        {
            _articleApiService = articleApiService;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            try
            {
                Articles = await _articleApiService.ArticleListAsync();
          
            }
            catch (Exception ex)
            {
                _logger.LogError($"Fetching artcles failed: {ex.Message}", ex);

                Articles = Enumerable.Empty<ArticleResource>();
            }
        }
    }
}
