$(document).ready(function () {
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