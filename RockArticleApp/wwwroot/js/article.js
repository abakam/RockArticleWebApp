$(function () {
    $(".like-button").on("click", function () {
        var articleId = $(this).data("id");
        $.get(`?handler=LikeArticle&articleId=${articleId}`, (data) => {
            $(".like-count").append(`${data.articleLikesCount}`)
        });
    });
});