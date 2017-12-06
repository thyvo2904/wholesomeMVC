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