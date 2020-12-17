using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RockArticleApp.Models;
using RockArticleApp.Pages;
using RockArticleApp.Services;

namespace RockArticleApp.ViewComponents
{
    public class LikeButtonViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ArticleModel articleLikes)
        {
            return View(articleLikes);
        }
    }
}
