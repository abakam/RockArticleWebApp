using System;
using RockArticleApp.Models.Resources;

namespace RockArticleApp.Models.Responses
{
    public class ArticleLikeResponse : BaseResponse<ArticleLikeResource>
    {

        public ArticleLikeResponse(ArticleLikeResource articleLike) : base(articleLike)
        { }

        public ArticleLikeResponse(string message) : base(message)
        { }
    }
}
