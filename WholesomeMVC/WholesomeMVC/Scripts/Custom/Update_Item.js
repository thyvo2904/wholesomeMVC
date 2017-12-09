$(document).ready(function () {
	// set up toggle function for edit view
	$("#link_add_manual").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#add_usda_match_view").hide();
		$("#add_manual_view").show();
	});
	$("#link_add_usda_match").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#add_manual_view").hide();
		$("#add_usda_match_view").show();
	});
	// set up default add view
	$("#link_add_manual").click();

	// set up toggle function for edit view
	$("#link_old_view").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#hidden_view_mode").val("old");
	});
	$("#link_new_view").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#hidden_view_mode").val("new");
	});
	// set up default edit view
	$("#link_old_view").click();


	// format table with footable
	$("#gridMatchedCeresIDS").footable({
		// options go here
		"expandFirst": false,
		"showToggle": true,
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
			"position": "right"
		},
		"state": {
			"enabled": true
		},
		"editing": {
			"enabled": true,
			"allowDelete": false,
			"addRow": function () {
				$("#add_item_view").modal("show");
			},
			"editRow": function (row) {
				// get data
				$("#hidden_ceresid").val(row.value["col1"]);
				$("#hidden_ceres_name").val(row.value["col2"]);
                $("#hidden_ndbno").val(row.value["col3"]);
                $("#hidden_nrf6").val(row.value["col4"]);

				// trigger ajax
				$("#button_expand_item").click();

				// expand modal
				if ($("#hidden_view_mode").val() === "old") {
					$("#expanded_old_view").modal("show");
				} else {
					$("#expanded_new_view").modal("show");
				}
			}
		}
	});
});