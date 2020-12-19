using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RockArticleApp.Models;
using RockArticleApp.Models.Resources;

namespace RockArticleApp.Services
{
    public interface IArticleApiService
    {
        Task<IEnumerable<ArticleResource>> ArticleListAsync();
        Task<ArticleLike> GetArticleLikesAsync(string articleId);
        Task<ArticleLike> LikeArticleAsync(string articleId);
    }
}
