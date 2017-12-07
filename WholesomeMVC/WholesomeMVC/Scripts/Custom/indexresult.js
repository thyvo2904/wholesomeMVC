$($(".expend-button").click(function () {
	$("#lblNdbno").val(this.id);
	$("#button_expand_item").click();
});

    $('#easyPaginate').easyPaginate({
        paginateElement: 'img',
        elementsPerPage: 3,
        effect: 'climb'
    });