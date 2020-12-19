using System;
namespace RockArticleApp.Models.Resources
{
    public class ArticleLikeResource
    {
        public string ArticleId { get; set; }
        public long ArticleLikesCount { get; set; }
        public bool HasBeenLiked { get; set; }
    }
}
