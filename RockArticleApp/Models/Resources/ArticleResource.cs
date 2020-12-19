using System;
namespace RockArticleApp.Models.Resources
{
    public class ArticleResource : ArticleLikeResource
    {
        public string ArticleTitle { get; set; }
        public string ArticleContentLocation { get; set; }
        // List of authors details 
    }
}
