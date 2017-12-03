$(document).ready(function () {
	$('.equal-height').matchHeight({
		byRow: true,
		property: 'height',
		target: null,
		remove: false
	});

	// create error message box when an error message exists
	if ($("#error_message").val()) {
		$("#content_header").before(`
			<!-- alert message for exception handling -->
			<section id="error_box" class="alert alert-danger alert-dismissable" role="alert">
				<button type="button" class="close" data-dismiss="alert" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
				${$("#error_message").val()}
			</section>
		`);
	}

	// create success message box when an success message exists
	if ($("#success_message").val()) {
		$("#content_header").before(`
			<!-- alert message for success confirmation -->
			<section id="success_box" class="alert alert-success alert-dismissable" role="alert">
				<button type="button" class="close" data-dismiss="alert" aria-label="Close">
					<span aria-hidden="true">&times;</span>
				</button>
				${$("#success_message").val()}
			</section>
		`);
	}
});

$(".save-button").click(function () {
	$("#hidden_item_index").val(this.id);
	$("#button_save_item").click();
});