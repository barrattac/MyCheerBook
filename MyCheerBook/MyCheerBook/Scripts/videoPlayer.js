//movie = clicked area(container for video)
//startHeight, and startWidth = screen size in full screen.
var movie, startHeight, startWidth;

//Determines which video was clicked and enters full screen
$(".images").click(function () {
    movie = this;
    $(movie).addClass("videoFull");    //class used for identification of selected video
    $(movie).removeClass("images")    //Next 2 lines, Removes classes that limits video size and location
    $(".videoFull video").removeClass("video")
    if ($(".videoFull video").get(0).requestFullscreen) {
        $(".videoFull video").get(0).requestFullscreen();   //IE
    } else if ($(".videoFull video").get(0).mozRequestFullScreen) {
        $(".videoFull video").get(0).mozRequestFullScreen(); // Firefox
    } else if ($(".videoFull video").get(0).webkitRequestFullscreen) {
        $(".videoFull video").get(0).webkitRequestFullscreen(); // Chrome and Safari
    }
    $(".videoFull video").get(0).currentTime = 0;   //sets the video back to the beginning of the movie
    $(".videoFull video").get(0).play();    //plays video
    setTimeout(windowResize, 1000);
});

//Determines if fullscreeen is exited and resizes video
function windowResize() {
    if (startHeight == null) {  //set full screen size
        startHeight = window.innerHeight;
        startWidth = window.innerWidth;
        setTimeout(windowResize, 30);
    }
    else if (window.innerHeight != startHeight || window.innerWidth != startWidth) {    //checks screen size against full screen size
        $(".videoFull video").get(0).pause();   //pauses the video
        $(".videoFull video").addClass("video");         //Next 2 lines, add classes that limit video size and location
        $(movie).addClass("images");
        $(movie).removeClass("videoFull");        //removes class that identifies selected video
    }
    else {
        setTimeout(windowResize, 30);
    }
}