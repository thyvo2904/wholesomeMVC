$(document).ready(function () {
	// set up toggle function for view
	$("#old_li").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#new_view").hide();
		$("#old_view").show();

        $("#view_mode").val("old");
	});
	$("#new_li").click(function () {
		$(this).parent().addClass("active");
		$(this).parent().siblings().removeClass("active");

		$("#old_view").hide();
		$("#new_view").show();

        $("#view_mode").val("new");
	})
	if ($("#view_mode").val() === "old") {
		$("#old_li").click();
	}
	if ($("#view_mode").val() === "new") {
		$("#new_li").click();
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