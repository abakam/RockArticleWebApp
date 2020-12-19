using System;
using Microsoft.AspNetCore.Components;

namespace RockArticleApp.Pages.Components.RazorComponents
{
    public class RockArticleBase : ComponentBase
    {
        [Parameter]
        public string ArticleId { get; set; }
        [Parameter]
        public long ArticleLikesCount { get; set; }
        [Parameter]
        public bool HasBeenLiked { get; set; }
    }
}
