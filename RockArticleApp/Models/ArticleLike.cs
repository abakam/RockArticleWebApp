using System;
namespace RockArticleApp.Models
{
    public class ArticleLike
    {
        public string ArticleId { get; set; }
        public long ArticleLikesCount { get; set; }
        public bool HasBeenLiked { get; set; }
    }
}
