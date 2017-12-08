$(document).ready(function () {
	$(".expend-button").click(function () {
		$("#lblNdbno").val(this.id);
		$("#button_expand_item").click();
	});

	// create pagination
	const ITEM_PER_PAGE = 16;
	let initPagination = function (ITEM_PER_PAGE) {
		let totalItems = $(".search_results > li").length;
		let numOfPages;

		if ((totalItems % ITEM_PER_PAGE) === 0) {
			numOfPages = Math.floor(totalItems / ITEM_PER_PAGE);
		} else {
			numOfPages = Math.floor((totalItems / ITEM_PER_PAGE) + 1);
		}

		let navContent = "<li><a class='nav_prev' aria-label='Previous'><span aria-hidden='true'>&laquo;</span></a></li>";
		for (var pageNumber = 1; pageNumber <= numOfPages; pageNumber++) {
			navContent += `<li><a class='nav_page'>${pageNumber}</a></li>`;
		}
		navContent += "<li><a class='nav_next' aria-label='Next'><span aria-hidden='true'>&raquo;</span></a></li>";
		$(".pagination").html(navContent);

		$(".search_results > li").each(function (index, item) {
			if (index < ITEM_PER_PAGE) {
				$(item).show();
			} else {
				$(item).hide();
			}
		});
		$($(".pagination > li")[1]).addClass("active");
		$(".nav_prev").parent().addClass("disabled");
	};
	initPagination(ITEM_PER_PAGE);

	// navigate by page number
	let navToPage = function (pageNumber) {
		$(".search_results > li").each(function (index, item) {
			if (index < (ITEM_PER_PAGE * pageNumber) &&
				index >= (ITEM_PER_PAGE * (pageNumber - 1))) {
				$(item).show();
			} else {
				$(item).hide();
			}
		});
		$(".pagination .active").removeClass("active");
		$($(".pagination > li")[pageNumber]).addClass("active");

		if ($(".pagination .active").index() === 1) {
			$(".nav_prev").parent().addClass("disabled");
		} else {
			$(".nav_prev").parent().removeClass("disabled");
		}

		if ($(".pagination .active").index() === ($(".pagination > li").length - 2)) {
			$(".nav_next").parent().addClass("disabled");
		} else {
			$(".nav_next").parent().removeClass("disabled");
		}
	};
	$(".nav_page").click(function () {
		navToPage($(this).text());
	})

	// navigate by prev/next
	let navPrevNext = function (direction) {
		let currentPage = parseInt($(".pagination .active > a").html());

		if (direction === "prev") { navToPage(currentPage - 1); }
		if (direction === "next") { navToPage(currentPage + 1); }
	};
	$(".nav_prev").click(function (event) {
		if ($(".nav_prev").parent().hasClass("disabled")) {
			event.preventDefault();
		} else {
			navPrevNext("prev");
		}
	});
	$(".nav_next").click(function (event) {
		if ($(".nav_next").parent().hasClass("disabled")) {
			event.preventDefault();
		} else {
			navPrevNext("next");
		}
	});
});