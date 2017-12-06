$(document).ready(function () {
	$('.equal-height').matchHeight({
		byRow: true,
		property: 'height',
		target: null,
		remove: false
	});

	$("#gridMatchedCeresIDS").footable({
		// options go here
		"expandFirst": true,
		"showToggle": true,
		"paging": {
			"enabled": true,
			"position": "center"
		},
		"sorting": {
			"enabled": true
		},
		"filtering": {
			"enabled": true,
			"delay": 0,
			"dropdownTitle": "Search in:",
			"position": "right",
		}
	});
});

$(".expend-button").click(function () {
	$("#hidden_ceres_name").val($(this).siblings(".hidden_ceres_name").val());
	$("#hidden_ceresid").val($(this).siblings(".hidden_ceresid").val());
	$("#hidden_ndbno").val($(this).siblings(".hidden_ndbno").val());
	$("#button_expand_item").click();
});