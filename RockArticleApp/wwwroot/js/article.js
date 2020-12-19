$(function () {
    $(".like-button").on("click", function () {
        var articleId = $(this).data("id");
        var articleLike = $(this).data("like");
        var likeCount = $(".like-count");
        if (articleLike) {
            var decrement = eval(`${likeCount.text()} - 1`);
            likeCount.empty();
            likeCount.append(`${decrement}`);
            $(this).removeClass("btn-primary");
            $(this).addClass("btn-secondary");
            $(this).data("like", !articleLike);

        } else {
            var increment = eval(`${likeCount.text()} + 1`);
            likeCount.empty();
            likeCount.append(`${increment}`);
            $(this).removeClass("btn-secondary");
            $(this).addClass("btn-primary");
            $(this).data("like", !articleLike);
        }
        
        /*$.get(`?handler=LikeArticle&articleId=${articleId}`, (data) => {
            $(".like-count").append(`${data.articleLikesCount}`);
        });*/
    });
});