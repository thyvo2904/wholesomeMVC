$(document).ready(function () {
	$('.equal-height').matchHeight({
		byRow: true,
		property: 'height',
		target: null,
		remove: false
	});
});

$(".expend-button").click(function () {
	$("#hidden_ceres_name").val($(this).siblings(".hidden_ceres_name").val());
	$("#hidden_ceresid").val($(this).siblings(".hidden_ceresid").val());
	$("#hidden_ndbno").val($(this).siblings(".hidden_ndbno").val());
	$("#button_expand_item").click();
});

$(function () {
    $('[id*=gridMatchedCeresIDS]').footable();
});

function showDiv(elem) {
    if (elem.value === 0) {
        document.getElementById('document.getElementById("divold")').style.display = "block";
        document.getElementById('divnew').style.display = "none";
        document.getElementById('divgridview').style.display = "none";
    } else if (elem.value === 1) {
        document.getElementById('divnew').style.display = "block";
        document.getElementById('divold').style.display = "none";
        document.getElementById('divnew').style.display = "none";
    } else if (elem.value === 2) {
        document.getElementById('divnew').style.display = "none";
        document.getElementById('divold').style.display = "none";
        document.getElementById('divgridview').style.display = "block";

    } else {
        document.getElementById('divold').style.display = "block";
        document.getElementById('divnew').style.display = "none";
        document.getElementById('divgridview').style.display = "block";
    }
}