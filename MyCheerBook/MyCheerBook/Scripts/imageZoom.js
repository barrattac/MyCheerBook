//pic = image clicked on
//zoom = determines if image is already zoomed
var pic;
var zoom = false;

$(".image").click(function () {
    if (zoom) {     //image already zoomed
        $(pic).css("border", "none");   //removes border
        $(pic).removeClass("zoom");     //removes class that identifies the image
        $(pic).addClass("image");       //add class that limits the image size and location
        zoom = false;
    }
    else {
        pic = this;
        $(pic).removeClass("image");    //removes class that limits the image size and location
        $(pic).addClass("zoom");        //class used to identify image, resize, and relocate clicked image
        $(".zoom").css("border", "5px solid white");    //adds a border on images while zoomed
        zoom = true;
    }
});