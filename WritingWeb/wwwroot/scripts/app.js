$(document).ready(function () {
    var typingTimer;
    var autosaveTimer;
    var doneTypingInterval = 100;
    var autosaveInterval = 3000;
    var currentWrittenWords = 0;
    var uniqueDayId = 0;
    var currentPathDayId = 0;
    $(document).on("keydown", "#txt", function () {
        clearInterval(typingTimer);
        clearInterval(autosaveTimer);
        if ($('#txt').val()) {
            typingTimer = setTimeout(function () {
                currentWrittenWords = countWords($('#txt').val());
                doneTyping(currentWrittenWords);
            }, doneTypingInterval);
            autosaveTimer = setTimeout(function () {
                uniqueDayId = +$("#current-day-uniqueID").text();
                currentPathDayId = +$("#current-path-DayNumber").text();
                saveToDB(currentWrittenWords, $('#txt').val(), uniqueDayId, currentPathDayId - 1);
            }, autosaveInterval);
        }
    });
});
function doneTyping(newText) {
    $('#written-words').text(newText);
    checkProgress(newText);
}
function checkProgress(currentWrittenWords) {
    var requiredWords = +$("#writing-day-required-words").text();
    var percentageCompleted = (currentWrittenWords * 100) / requiredWords;
    var percentageFloored = Math.floor(percentageCompleted);
    if (percentageFloored >= 100) {
        percentageFloored = 100;
        checkCompletion(currentWrittenWords);
    }
    updateSlider(percentageFloored);
}
function updateSlider(byPercentage) {
    $("#writing-progress-bar .progress-slider").css("width", byPercentage + "%").css({
        transition: 'width .8s ease-in-out'
    });
}
function checkCompletion(currentWrittenWords) {
    var requiredWords = +$('#writing-day-required-words').text();
    if (currentWrittenWords >= requiredWords) {
        var currentDayRewardID = +$("#current-day-rewardID").text();
        dayAlreadyAccomplished(currentDayRewardID);
    }
}
function dayAlreadyAccomplished(dayID) {
    $.ajax({
        url: "Writer/DayAccomplished/" + dayID,
        contentType: "text/plain",
        method: "GET",
        success: function (data) {
            if (data == false) {
                getReward(dayID);
            }
        }
    });
}
function getReward(dayID) {
    $.ajax({
        url: "WritingArea/GetReward/" + dayID,
        contentType: "text/plain",
        method: "GET",
        success: function (data) {
            displayReward(data);
        }
    });
}
function displayReward(data) {
    $('#writing-day-reward').html(data).removeClass('writing-area-hidden');
}
function saveToDB(wordsWrittenCount, writtenText, uniqueDayId, currentPathDayId) {
    $('#autosave-info').text("Saving... ");
    $.ajax({
        url: "WritingArea/SaveDay/" + currentPathDayId,
        contentType: "application/json",
        method: "POST",
        data: JSON.stringify({ Id: uniqueDayId, PathId: 0, DayId: currentPathDayId, WrittenText: writtenText, WrittenWords: wordsWrittenCount }),
        success: function (data) {
            var savedTime = new Date();
            $('#autosave-info').text("Saved at " + savedTime.getHours() + ":" + savedTime.getMinutes() + " * " + savedTime.toISOString().slice(0, 10) + " * ");
            updatePath();
        }
    });
}
function claimReward(dayID) {
    $('#writing-day-reward').html('<div>Awaiting Reward</div>').addClass('writing-area-hidden');
    var currentDayRewardID = +$("#current-day-rewardID").text();
    $.ajax({
        url: "Writer/ClaimReward/" + currentDayRewardID,
        contentType: "text/plain",
        method: "GET",
        success: function (data) {
            $("#writer-profile-component").html(data);
            accomplishDay(dayID);
        }
    });
}
function accomplishDay(dayID) {
    $.ajax({
        url: "WritingArea/AccomplishDay/" + dayID,
        contentType: "text/plain",
        method: "GET",
        success: function () {
            updatePath();
        }
    });
}
function updatePath() {
    pathIsActive = false;
    getWritingPath();
}
function countWords(inTextArea) {
    inTextArea = prepareForCounting(inTextArea);
    var words = inTextArea.split(' ');
    var text = clearWhiteSpace(inTextArea);
    var wordCount = text.split(' ').length;
    if (text === "") {
        wordCount -= 1;
    }
    var forbiddenWords = countForbiddenWords(words);
    return wordCount - forbiddenWords;
}
function prepareForCounting(incomingString) {
    incomingString = incomingString.toLowerCase();
    incomingString = removeNonWordCharacters(incomingString);
    incomingString = removeNumbers(incomingString);
    incomingString = removeSingleLetters(incomingString);
    return incomingString;
}
function removeNonWordCharacters(inString) {
    return inString.replace(/[\<\>\@\#\$\%\^\&\*\(\)\-\=\!\\_\+\,\.\:\;\?\|\{\}\[\]\'\"\/\`\~]/g, " ");
}
function removeNumbers(inString) {
    return inString.replace(/[0-9]/g, " ");
}
function removeSingleLetters(inString) {
    return inString.replace(/\b[A-Za-z]\b/g, " ");
}
function clearWhiteSpace(inString) {
    inString = inString.replace(/(^\s*)|(\s*$)/gi, "");
    inString = inString.replace(/[ ]{2,}/gi, " ");
    inString = inString.replace(/\n /, "\n");
    return inString;
}
function countForbiddenWords(inWords) {
    var forbiddenWords = 0;
    var i;
    var j;
    for (i = 0; i < inWords.length; i += 1) {
        for (j = 0; j < stopwords.length; j += 1) {
            if (inWords[i] === stopwords[j]) {
                forbiddenWords += 1;
            }
        }
    }
    return forbiddenWords;
}
var stopwords = ['a', 'all', 'an', 'and', 'are', 'as', 'at', 'be', 'but',
    'by', 'can', 'do', 'for', 'from', 'had', 'have', 'if', 'in', 'is', 'it',
    'me', 'my', 'no', 'not', 'of', 'on', 'or', 'our', 's', 'so', 't', 'that',
    'the', 'their', 'they', 'this', 'to', 'us', 'was', 'we', 'who', 'with', 'you'];
function getWritingDay(dayId) {
    $.get("WritingArea/GetDay/" + dayId, function (data) {
        $("#writing-area").html(data).removeClass("writing-area-hidden");
    });
}
var pathIsActive = false;
function getWritingPath() {
    if (pathIsActive) {
        $("#writing-path-component").toggleClass("writing-path-hidden");
        return;
    }
    else {
        $.get("WritingPath", function (data) {
            $("#writing-path-component").html(data).removeClass("writing-path-hidden");
            pathIsActive = true;
        });
    }
}
var writerProfileIsActive = false;
function getWriterProfile() {
    if (writerProfileIsActive) {
        $("#writer-profile-component").toggleClass("writer-profile-hidden");
        return;
    }
    else {
        $.get("Writer/GetWriter", function (data) {
            $("#writer-profile-component").html(data).removeClass("writer-profile-hidden");
            writerProfileIsActive = true;
        });
    }
}
function displayHiddenQuote(dayID) {
    $.get("WritingPath/" + dayID, function (data) {
        $("#quote-of-the-day").html(data).removeClass("hidden-quote");
    });
}
function changeMessage(message) {
    if (message.length <= 1) {
        return;
    }
    $("#quote-of-the-day").text(message);
    $("#quote-of-the-day").removeClass('hidden-quote');
}
function hideHiddenMessageOfTheDay() {
    $("#quote-of-the-day").addClass('hidden-quote');
}
function openWritingArea() {
    $("#writing-area").toggleClass("writing-area-hidden");
}
function closeWritingArea() {
    $("#writing-area").addClass("writing-area-hidden");
}
//# sourceMappingURL=app.js.map