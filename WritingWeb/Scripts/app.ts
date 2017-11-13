$(document).ready(function () {
    var typingTimer: number;
    var autosaveTimer: number;
    var doneTypingInterval = 100;
    var autosaveInterval = 3000;

    var currentWrittenWords = 0;
    var uniqueDayId = 0;
    var currentPathDayNumber = 0;

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
                currentPathDayNumber = +$("#current-path-DayNumber").text();
                saveToDB(currentWrittenWords, $('#txt').val(), uniqueDayId, currentPathDayNumber - 1);
            }, autosaveInterval);
        }
    });
});

function doneTyping(newText: number): void {
    $('#written-words').text(newText);
    checkProgress(newText);
}

function checkProgress(currentWrittenWords: number): void {
    var requiredWords: number = +$("#writing-day-required-words").text();
    var percentageCompleted: number = (currentWrittenWords * 100) / requiredWords;
    var percentageFloored: number = Math.floor(percentageCompleted);

    if (percentageFloored >= 100) {
        percentageFloored = 100;
        checkCompletion(currentWrittenWords);
    }
    updateSlider(percentageFloored);
}

function updateSlider(byPercentage: number): void {
    $("#writing-progress-bar .progress-slider").css("width", byPercentage + "%").css({
        transition: 'width .8s ease-in-out'
    });
}

function checkCompletion(currentWrittenWords: number): void {
    var requiredWords: number = +$('#writing-day-required-words').text();
    if (currentWrittenWords >= requiredWords) {
        var currentDayRewardID = +$("#current-day-rewardID").text();

        dayAlreadyAccomplished(currentDayRewardID);
    }
}

function dayAlreadyAccomplished(dayID: number): void {
    $.ajax({
        url: "Writer/DayAccomplished/" + dayID,
        contentType: "text/plain",
        method: "GET",
        success: function (data: boolean) {
            if (data == false) {
                getReward(dayID);   /*todo day accomplished by accomplished day not by received reward*/
            }
        }
    })
}

function getReward(dayID: number): void {
    // todo : Secure: Don't Display Reward if It's Already Received
    $.ajax({
        url: "WritingArea/GetReward/" + dayID,
        contentType: "text/plain",
        method: "GET",
        success: function (data) {
            displayReward(data);
        }
    })
}

function displayReward(data: string): void {
    //TODO: PLAY MUSIC & ANIMATION
    $('#writing-day-reward').html(data).removeClass('writing-area-hidden');
}

function saveToDB(wordsWrittenCount: number, writtenText: any, uniqueDayId: number, currentPathDayId: number): void {
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
    })
}

function claimReward(dayID: number):void {
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
    })
    //TODO: SHOW UP ACHIEVEMENT

    //$('#claim-reward').click(function () {
    //    $('#achievement-unlocked').addClass('hidden');
    //});
}

function accomplishDay(dayID: number): void {
    $.ajax({
        url: "WritingArea/AccomplishDay/" + dayID,
        contentType: "text/plain",
        method: "GET",
        success: function () {
            updatePath();
        }
    })
    // todo : << HERE GET REWARD, ONLY AFTER CLICK OF A BUTTON, IF THIS DIDN"T HAPPEN _> USER WILL GET REWARD NEXT TIME HE LOGS IN TO THE SAME DAY
}

function updatePath() {
    pathIsActive = false;
    getWritingPath();
}

function countWords(inTextArea: any): number {
    inTextArea = prepareForCounting(inTextArea);
    var words: string[] = inTextArea.split(' ');

    var text = clearWhiteSpace(inTextArea);
    var wordCount = text.split(' ').length;

    if (text === "") { wordCount -= 1; }

    var forbiddenWords = countForbiddenWords(words);

    return wordCount - forbiddenWords;
}

function prepareForCounting(incomingString: string): string {
    incomingString = incomingString.toLowerCase();
    incomingString = removeNonWordCharacters(incomingString);
    incomingString = removeNumbers(incomingString);
    incomingString = removeSingleLetters(incomingString);

    return incomingString;
}

function removeNonWordCharacters(inString: string) {
    return inString.replace(/[\<\>\@\#\$\%\^\&\*\(\)\-\=\!\\_\+\,\.\:\;\?\|\{\}\[\]\'\"\/\`\~]/g, " ");
}

function removeNumbers(inString: string): string {
    return inString.replace(/[0-9]/g, " ");
}

function removeSingleLetters(inString: string): string {
    return inString.replace(/\b[A-Za-z]\b/g, " ");
}

function clearWhiteSpace(inString: string): string {
    inString = inString.replace(/(^\s*)|(\s*$)/gi, "");
    inString = inString.replace(/[ ]{2,}/gi, " ");
    inString = inString.replace(/\n /, "\n");

    return inString;
}

function countForbiddenWords(inWords: string[]): number {

    var forbiddenWords: number = 0;
    var i: number;
    var j: number;
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

//API METHODS

function getWritingDay(dayId: number): void {
    $.get("WritingArea/GetDay/" + dayId, function (data) {
        $("#writing-area").html(data).removeClass("writing-area-hidden");
    });
    //todo: if area is visible?
    // todo: if the day is different than the one currently in use?
}

var pathIsActive: boolean = false;

function getWritingPath(): void {
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

var writerProfileIsActive: boolean = false;

function getWriterProfile(): void {
    if (writerProfileIsActive) {
        $("#writer-profile-component").toggleClass("writer-profile-hidden");
        return;
    }
    else {
        $.get("Writer/GetWriter", function (data) {
            $("#writer-profile-component").html(data).removeClass("writer-profile-hidden");
            writerProfileIsActive = true;
        })
    }
}

//View Methods

function displayHiddenQuote(dayID: number): void {
    $.get("WritingPath/" + dayID, function (data) {
        $("#quote-of-the-day").html(data).removeClass("hidden-quote");
    });
}

function changeMessage(message: string): void {
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