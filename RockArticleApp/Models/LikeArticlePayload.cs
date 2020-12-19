using System;
namespace RockArticleApp.Models
{
    public class LikeArticlePayload
    {
        public string ArticleId { get; set; }
        public bool HasBeenLiked { get; set; }
    }
}
