let likereaction = 0;
let DISLIKEREACTION = 0;
let viewsreact = 0;

function viewz() {

    viewsreact += 1;
    document.getElementById("VIEW2").innerHTML = viewsreact;
}
$(document).ready(function () {

    viewz();
   



    $("#likee3").on({
        click: function () {
            likereaction += 1;
            document.getElementById("likee").innerHTML = likereaction;
        }
    });





    $("#DISLIKE1").on({
        click: function () {
            DISLIKEREACTION += 1;
            document.getElementById("DISLIKE2").innerHTML = DISLIKEREACTION;
        }
    });











})

