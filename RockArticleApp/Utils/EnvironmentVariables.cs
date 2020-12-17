using System;
namespace RockArticleApp.Utils
{
    public class EnvironmentVariables
    {
        public string ArticleApiBaseUrl => "ROCKARTICLEAPI_BASEURL";
        public string ArticleApiGetLikesPath => "ROCKARTICLEAPI_GETLIKESPATH";
        public string ArticleApiLikeArticlePath => "ROCKARTICLEAPI_LIKEARTICLEPATH";
    }
}
