using System;
using System.Threading.Tasks;
using RockArticleApp.Models;

namespace RockArticleApp.Services
{
    public interface IArticleApiService
    {
        Task<ArticleLike> GetArticleLikesAsync(string articleId);
        Task<ArticleLike> LikeArticleAsync(string articleId);
    }
}
