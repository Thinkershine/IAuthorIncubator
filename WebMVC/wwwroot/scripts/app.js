function getWritingDay(pathId, dayId) {
    $.get("WritingArea/GetDay/" + pathId + "/" + dayId, function (data) {
        $("#writing-area").html(data).removeClass("writing-area-hidden");
    });
}
//# sourceMappingURL=app.js.map