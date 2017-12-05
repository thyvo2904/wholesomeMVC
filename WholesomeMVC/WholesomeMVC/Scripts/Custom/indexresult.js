$(document).ready(function () {
	$('.equal-height').matchHeight({
		byRow: true,
		property: 'height',
		target: null,
		remove: false
	});
});

$(".expend-button").click(function () {
	$("#lblNdbno").val(this.id);
	$("#button_expand_item").click();
});