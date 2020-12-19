using System;
using RockArticleApp.Models.Resources;

namespace RockArticleApp.Models.Responses
{
    
    public class ArticleResponse : BaseResponse<ArticleResource>
    {
        
        public ArticleResponse(ArticleResource article) : base(article)
        { }

        public ArticleResponse(string message) : base(message)
        { }
    }
}
