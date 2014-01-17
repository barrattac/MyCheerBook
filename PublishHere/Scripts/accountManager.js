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
    $("#name td:nth-child(3)").hide();
    $("#name td:nth-child(2)").hide();
    $("#firstName").show();
    $("#button").show();
});

//Add lastname field to form
$("#name2").click(function () {
    $("#name2 td:nth-child(3)").hide();
    $("#name2 td:nth-child(2)").hide();
    $("#lastName").show();
    $("#button").show();
});

//Add email field to form
$("#email").click(function () {
    $("#email td:nth-child(3)").hide();
    $("#email td:nth-child(2)").hide();
    $("#emailBox").show();
    $("#button").show();
});

//Add password field to form
$("#password").click(function () {
    $("#password td:nth-child(3)").hide();
    $("#password td:nth-child(2)").hide();
    $("#newPass").show();
    $("#confirmPass").show();
    $("#button").show();
});