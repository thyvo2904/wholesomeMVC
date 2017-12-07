$(document).ready(function () {
	// format table with footable
	console.log($("#gridFarmersMarket"));
	$("#gridFarmersMarket").footable({
		// options go here
		"paging": {
			"enabled": true,
			"position": "left"
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