var dt, now;

$(document).ready(function () {
    dt = Date(document.getElementById("date"));
    timePassed();
});

function timePassed() {
    now = Date().getTime()
    $("#date").append(now - dt);
    setTimeout(timePassed, 1000);
}