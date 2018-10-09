$(document).ready(function () {

    //script for going button
    $(".js-toggle-attendance").click(function (e) {
        var button = $(e.target);
        $.post("/api/attendances", { gigId: button.attr("data-gig-id") })
            .done(function () {
                if (button.hasClass("btn-info")) {
                    button
                        .removeClass("btn-info")
                        .addClass("btn-default")
                        .text("Going?")
                }
                else {
                    button
                        .removeClass("btn-default")
                        .addClass("btn-info")
                        .text("Going");
                }
            })
            .fail(function () {
                alert("Something failed");
            });
    });

    //script for follow button
    $(".follow").click(function (e) {
        var button = $(e.target);
        var idUser = button.attr("data-following-id");
        var arrayButton = $(".follow[data-following-id='"+idUser+"']");
        $.post("/api/follows", {followingId: button.attr("data-following-id") })
            .done(function () {                                                     
                    if (arrayButton.hasClass("btn-info")) {
                        arrayButton
                            .removeClass("btn-info")
                            .addClass("btn-default")
                            .text("Follow");
                    }
                    else {
                        arrayButton
                            .removeClass("btn-default")
                            .addClass("btn-info")
                            .text("Followed");
                    }
            })
            .fail(function () {
                alert("Someting failed");
            });
    });

    //script for remove button
    $(".btn-warning").click(function () {
        alert("clicked");  //removing
    });

    //script for filter by attending checkbox
    $(".checkboxAttend").click(function () {
        $.post("/api/attendancefilter", function () {
            location.reload();
        });
    });

}); 