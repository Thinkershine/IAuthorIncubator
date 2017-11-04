$(document).ready(function () {
    var typingTimer;
    var autosaveTimer;
    var doneTypingInterval = 500;
    var autosaveInterval = 3000;
    var currentWrittenWords = 0;
    var currentWrittingDay = 0;
    $(document).on("keyup", "#txt", function () {
        clearInterval(typingTimer);
        clearInterval(autosaveTimer);
        if ($('#txt').val()) {
            currentWrittenWords = countWords($('#txt').val());
            currentWrittingDay = +$("#current-writing-dayID").text();
            typingTimer = setTimeout(function () { doneTyping(currentWrittenWords, currentWrittingDay); }, doneTypingInterval);
        }
    });
});
function doneTyping(newText, currentDayID) {
    $('#written-words').text(newText);
    checkProgress(newText, currentDayID);
}
function checkProgress(currentWrittenWords, dayID) {
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
    $(".progress-slider").css("width", byPercentage + "%").css({
        transition: 'width .8s ease-in-out'
    });
}
function saveToDB(wordsWrittenCount, textWritten) {
    $('#autosave-info').text("Autosaved... at " + new Date().toISOString().slice(0, 10));
    checkCompletion(wordsWrittenCount);
}
function checkCompletion(currentWrittenWords) {
    var requiredWords = +$('#writing-day-required-words').text();
    if (currentWrittenWords >= requiredWords) {
        $.ajax({
            url: "writingarea/getreward/" + +$("#current-writing-dayID").text(),
            contentType: "text/plain",
            method: "GET",
            success: function (data) {
                console.log("SUCCESSFUL CONGRATULATE");
                displayReward(data);
            }
        });
    }
}
function displayReward(data) {
    $('#writing-day-reward').html(data).removeClass('writing-area-hidden');
}
function claimReward() {
    $('#writing-day-reward').html('<div>Awaiting Reward</div>').addClass('writing-area-hidden');
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
function getWritingDay(pathId, dayId) {
    $.get("WritingArea/GetDay/" + pathId + "/" + dayId, function (data) {
        setTimeout(function () { $("#writing-area").html(data).removeClass("writing-area-hidden"); }, 1000);
    });
}
var pathIsActive = false;
function getWritingPath() {
    if (pathIsActive) {
        $("#writing-path-component").toggleClass("writing-path-hidden");
        return;
    }
    else {
        var pathID = 0;
        $.get("WritingPath/" + pathID, function (data) {
            $("#writing-path-component").html(data).removeClass("writing-path-hidden");
            pathIsActive = true;
        });
    }
}
function displayHiddenQuote(pathID, dayID) {
    $.get("WritingPath/" + pathID + "/" + dayID, function (data) {
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
//# sourceMappingURL=app.js.map