$("#old_li").addClass("active");

$("#old_view").css("display", "block");
$("#new_view").css("display", "none");

$("#view_mode").val("old");

function switchView() {
    if ($("#old_li").hasClass("active")) {
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