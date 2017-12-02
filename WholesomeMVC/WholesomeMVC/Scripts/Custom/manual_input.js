$(document).ready(function () {
	console.log($("#view_mode").val())
	if ($("#view_mode").val() === "old") {
		$("#old_li").addClass("active");

		$("#old_view").css("display", "block");
		$("#new_view").css("display", "none");

		$("#view_mode").val("old");
	} else {
		$("#new_li").addClass("active");

		$("#new_view").css("display", "block");
		$("#old_view").css("display", "none");

		$("#view_mode").val("new");
	}
});

function switchView() {
	console.log($("#view_mode").val())
	if ($("#view_mode").val() === "old") {
		$("#old_li").removeClass("active");
		$("#old_view").css("display", "none");

		$("#new_li").addClass("active");
		$("#new_view").css("display", "block");

		$("#view_mode").val("new");
	} else {
		$("#new_li").removeClass("active");
		$("#new_view").css("display", "none");

		$("#old_li").addClass("active");
		$("#old_view").css("display", "block");

		$("#view_mode").val("old");
	}
}