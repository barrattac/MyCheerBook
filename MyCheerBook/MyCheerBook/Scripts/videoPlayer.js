$(document).ready(function () {
    $(".videoControls").hide();
});

var movie;
var playing = false;
var zoom = false;
var overButtons = false;

$(".images").click(function () {
    if (!zoom) {
        movie = this;
        $(movie).removeClass("images");
        $(movie).addClass("zoom");
        $(".zoom video").removeClass("video");
        $(".zoom video").get(0).play();
        playing = true;
        zoom = true;
    }
});

function showControls() {
    $(".videoControls").show();
    if (zoom) {
        if (playing) {
            $("#play").show();
        }
        else {
            $("#pause").show();
        }
        $("#seek").show();
        $("#mute").show();
        $("#volume").show();
        $("#full").show();
        $("#close").show();
    }
}

$(".images").mouseenter(function () {
    showControls();
});

$(".videoControls").mouseenter(function () {
    overButtons = true;
    showControls();
});

function hideButtons() {
    $(".videoControls").hide();
    $("#play").hide();
    $("#pause").hide();
    $("#seek").hide();
    $("#mute").hide();
    $("#volume").hide();
    $("#full").hide();
    $("#close").hide();
}

$(".images").mouseleave(function () {
    if (!overButtons) {
        hideButtons();
    }

});

$(".videoControls").mouseenter(function () {
    overButtons = true;
    showControls();
});

$(".videoControls").mouseleave(function () {
    overButtons = false;
    hideButtons();
});

$("#close").click(function () {
    $(".zoom video").get(0).pause();
    $(".zoom video").addClass("video");
    $(movie).removeClass("zoom");
    $(movie).addClass("video");
    playing = false;
    zoom = false;
});