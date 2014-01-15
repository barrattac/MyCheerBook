var movie;
var playing = false;

$(".images").click(function () {
    if (playing) {
        $(".zoom video").get(0).pause();
        $(movie).css("border", "none");
        $(".zoom video").addClass("video");
        $(movie).removeClass("zoom");
        $(movie).addClass("video");
        playing = false;
    }
    else
    {
        movie = this;
        $(movie).removeClass("images");
        $(movie).addClass("zoom");
        $(".zoom video").removeClass("video");
        $(".zoom video").get(0).play();
        playing = true;
    }
});