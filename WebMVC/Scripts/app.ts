function getWritingDay(pathId: number, dayId: number) {
    $.get("WritingArea/GetDay/" + pathId + "/" + dayId, function (data) {
        $("#writing-area").html(data).removeClass("writing-area-hidden");
    });
}