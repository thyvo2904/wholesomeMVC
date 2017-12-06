$(function () {
    $('[id*=gridMatchedCeresIDS]').footable();
});

function showDiv(elem) {
    if (elem.value === 0) {
        document.getElementById('#divold').style.display = "block";
        document.getElementById('#divnew').style.display = "none";
        document.getElementById('#divgridview').style.display = "none";
    } else if (elem.value === 1) {
        document.getElementById('#divnew').style.display = "block";
        document.getElementById('#divold').style.display = "none";
        document.getElementById('#divnew').style.display = "none";
    } else if (elem.value === 2) {
        document.getElementById('#divnew').style.display = "none";
        document.getElementById('#divold').style.display = "none";
        document.getElementById('#divgridview').style.display = "block";

    } else {
        document.getElementById('#divold').style.display = "block";
        document.getElementById('#divnew').style.display = "none";
        document.getElementById('#divgridview').style.display = "block";
    }
}

$(document).ready(function () {

    // Custom settings
    $('.matchedCeresIDS').responsiveTable({
        staticColumns: 2,
        scrollRight: true,
        scrollHintEnabled: true,
        scrollHintDuration: 2000
    });
});