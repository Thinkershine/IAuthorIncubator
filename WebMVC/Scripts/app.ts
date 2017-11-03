$(document).ready(function () {
    var typingTimer: number;
    var autosaveTimer: number;
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
            //autosaveTimer = setTimeout(function () { saveToDB(currentWrittenWords, $('#txt').val()); }, autosaveInterval);
        }
    });

    //$('#claim-reward').click(function () {
    //    $('#achievement-unlocked').addClass('hidden');
    //    //TODO: SHOW ANIMATIONS HOW EXPERIENCE IS GROWING etc.
    //});
});


function doneTyping(newText: number, currentDayID: number): void {
    $('#written-words').text(newText);
    checkProgress(newText, currentDayID);
}

function checkProgress(currentWrittenWords: number, dayID: number): void {
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
    $(".progress-slider").css("width", byPercentage + "%").css({
        transition: 'width .8s ease-in-out'
    });
}

function saveToDB(wordsWrittenCount: number, textWritten: any): void {
    $('#autosave-info').text("Autosaved... at " + new Date().toISOString().slice(0, 10));
    checkCompletion(wordsWrittenCount);
    //TODO: OR COULD GET DATETIME FROM C# when SAVED? 
    //TODO: IF COMPLETED ON THE SERVER, SAVE Completed, add skill points, level up, badges etc. right away
    // > THEN UPDATE THE VIEW WITH NEXT METHOD
}

function checkCompletion(currentWrittenWords: number): void {
    var requiredWords: number = +$('#writing-day-required-words').text();
    if (currentWrittenWords >= requiredWords) {

        $.ajax({
            url: "writingarea/getreward/" + +$("#current-writing-dayID").text(),
            contentType: "text/plain",
            method: "GET",
            success: function (data) {
                console.log("SUCCESSFUL CONGRATULATE");
                displayReward(data);
            }
        })
        //TODO: SHOW UP ACHIEVEMENT 
        //TODO: STORE IN DB AS COMPLETED
        //TODO: ASSIGN POINTS, SHOW SKILL UP, LEVEL UP, ETC...
    }
}

function displayReward(data: string): void {
    //TODO: PLAY MUSIC & ANIMATION
    $('#writing-day-reward').html(data).removeClass('writing-area-hidden');
}

function claimReward() {
    $('#writing-day-reward').html('<div>Awaiting Reward</div>').addClass('writing-area-hidden');
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

function getWritingDay(pathId: number, dayId: number): void {
    $.get("WritingArea/GetDay/" + pathId + "/" + dayId, function (data) {
        setTimeout(function () { $("#writing-area").html(data).removeClass("writing-area-hidden") }, 1000); // todo: show awaiting indicator...?
    });
}

var pathIsActive: boolean = false;

function getWritingPath(): void {
    if (pathIsActive) {
        $("#writing-path-component").toggleClass("writing-path-hidden");
        return;
    }
    else {
        var pathID: number = 0;
        $.get("WritingPath/" + pathID, function (data) {
            $("#writing-path-component").html(data).removeClass("writing-path-hidden");
            pathIsActive = true;
        });
    }
}

//View Methods

function displayHiddenQuote(pathID: number, dayID: number): void {
    $.get("WritingPath/" + pathID + "/" + dayID, function (data) {
        $("#hidden-message-of-the-day").html(data).removeClass("hidden-message-of-the-day");
    });
}

function changeMessage(message: string): void {
    if (message.length <= 1) {
        return;
    }
    $("#message-of-the-day").text(message);
    $("#hidden-message-of-the-day").removeClass('hidden-message-of-the-day');
}

function hideHiddenMessageOfTheDay() {
    $("#hidden-message-of-the-day").addClass('hidden-message-of-the-day');
}