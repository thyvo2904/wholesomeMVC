$(document).ready(function () {
	$("#txtSearch").autocomplete({ source: '<%=ResolveUrl("~/AutoComplete.ashx" ) %>' });
});

$("#log_in_out").click(function () {
	if ($("#generatedToken").val() === "") {
		// do nothing
	} else {
		$("#tokenToSubmit").val($("#generatedToken").val());
		$("#logoutForm").submit();
	}
});