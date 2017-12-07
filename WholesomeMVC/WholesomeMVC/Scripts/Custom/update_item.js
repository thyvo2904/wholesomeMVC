$(document).ready(function () {
	// set up toggle function
	$("#link_old_view").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#hidden_view_mode").val("old");
	});
	$("#link_new_view").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#hidden_view_mode").val("new");
	})
	// set up default view
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
			"position": "right",
		},
		"editing": {
			"enabled": true,
			"allowDelete": false,
			"editRow": function (row) {
				// get data
				$("#hidden_ceresid").val(row.value["col1"]);
				$("#hidden_ceres_name").val(row.value["col2"]);
				$("#hidden_ndbno").val(row.value["col5"]);

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

function showDiv(elem) {
    if (elem.value === 0) {
        $("#divold").style.display = "block";
        $("#divnew").style.display = "none";
        $("#divgridview").style.display = "none";
    } else if (elem.value === 1) {
        $("#divnew").style.display = "block";
        $("#divold").style.display = "none";
        $("#divnew").style.display = "none";
    } else if (elem.value === 2) {
        $("#divnew").style.display = "none";
        $("#divold").style.display = "none";
        $("#divgridview").style.display = "block";

    } else {
        $("#divold").style.display = "block";
        $("#divnew").style.display = "none";
        $("#divgridview").style.display = "block";
    }
}