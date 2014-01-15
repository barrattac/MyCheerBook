var pic;
var zoom = false;

$(".image").click(function () {
    if (zoom) {
        $(pic).css("border", "none");
        $(pic).removeClass("zoom");
        $(pic).addClass("image");
        zoom = false;
    }
    else {
        pic = this;
        $(pic).removeClass("image");
        $(pic).addClass("zoom");
        $(".zoom").css("border", "5px solid white");
        zoom = true;
    }
});