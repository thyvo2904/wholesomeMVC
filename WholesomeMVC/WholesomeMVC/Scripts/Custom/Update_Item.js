$(document).ready(function () {
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
				$("#hidden_ceresid").val(row.value["col1"]);
				$("#hidden_ceres_name").val(row.value["col2"]);
				$("#hidden_ndbno").val(row.value["col5"]);
				$(".modal").modal("show");
				$("#button_expand_item").click();
			}
		}
	});

	// set up toggle function
	$("#link_old_view").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#old_view").show();
		$(".old_buttons").show();

		$("#new_view").hide();
		$(".new_buttons").hide();

		$("#hidden_view_mode").val("old");
	});
	$("#link_new_view").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#new_view").show();
		$(".new_buttons").show();

		$("#old_view").hide();
		$(".old_buttons").hide();

		$("#hidden_view_mode").val("new");
	})

	// set up default view
	$("#link_old_view").click();
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