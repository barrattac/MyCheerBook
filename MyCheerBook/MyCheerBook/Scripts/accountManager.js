//hide unused items on load
$(document).ready(function () {
    $("#firstName").hide();
    $("#lastName").hide();
    $("#emailBox").hide();
    $("#oldPass").hide();
    $("#newPass").hide();
    $("#confirmPass").hide();
    $("#button").hide();
});

//Add firstname field to form
$("#name").click(function () {
    var i = this;
    $(i).addClass("i");
    $(".i:nth-child(3)").hide();
    $(".i:nth-child(2)").hide();
    $(i).removeClass("i");
    $("#firstName").show();
    $("#button").show();
});

$("#name2").click(function () {
    $("#lastName").show();
    $("#button").show();
});

$("#email").click(function () {
    $("#emailBox").show();
    $("#button").show();
});

$("#password").click(function () {
    $("#oldPass").show();
    $("#newPass").show();
    $("#confirmPass").show();
    $("#button").show();
});