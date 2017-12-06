$(document).ready(function () {
	//for more information to use the typeahead library visit:
	//https://github.com/bassjobsen/Bootstrap-3-Typeahead

	var url = window.location.protocol + "//" + window.location.host + "/WebForms/autocomplete.ashx";
	//// option 1: get json on key release
	//$(".typeahead").keyup(function () {
	//	// only get json when user type two or more characters
	//	if ($(this).val().length > 2) {
	//		url += "?term=" + $(this).val();
	//		$.getJSON(url, function (data) {
	//			// data is the JSON string
	//
	//			// get all the names of items if data coming from API
	//			let names = [];
	//			$(data.list.item).each(index => { names.push(data.list.item[index].name); });
	//
	//			// instantiate autocomplete engine
	//			$(".typeahead").typeahead({
	//				source: names,
	//				showHintOnFocus: "all",
	//			});
	//		}, 'json');
	//	}
	//});

	// option 2: get json on page load
	$.getJSON(url, function (data) {
		//data is the JSON string

		//// get all the names of items if data coming from API
		//let names = [];
		//$(data.list.item).each(index => { names.push(data.list.item[index].name); });

		// instantiate autocomplete engine
		$(".typeahead").typeahead({
			source: data,
			// more options can be appended here
			fitToElement: false
		});
	}, 'json');
});

$("#log_in_out").click(function () {
	if ($("#generatedToken").val() === "") {
		// do nothing
	} else {
		$("#tokenToSubmit").val($("#generatedToken").val());
		$("#logoutForm").submit();
	}
});