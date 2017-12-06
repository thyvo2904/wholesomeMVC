$(document).ready(function () {
    // set default view
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

    // create error message box when an error message exists
    if ($("#error_message").val()) {
        $("#old_view").before(`
			<!-- alert message for exception handling -->
			<section id="error_box" class="alert alert-danger alert-dismissable" role="alert">
				<button type="button" class="close" data-dismiss="alert" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
				${$("#error_message").val()}
			</section>
		`);
    }
});

/**
 * switch view when click nab-tab
 */
function switchView() {
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