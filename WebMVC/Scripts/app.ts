$(document).ready(function () {
    var typingTimer: number;
    var autosaveTimer: number;
    var doneTypingInterval = 500;
    var autosaveInterval = 3000;

    var currentWrittenWords = 0;

    $(document).on("keyup", "#txt", function () {
        clearInterval(typingTimer);
        clearInterval(autosaveTimer);
        if ($('#txt').val()) {
            currentWrittenWords = countWords($('#txt').val());
            typingTimer = setTimeout(function () { doneTyping(currentWrittenWords); }, doneTypingInterval);
            autosaveTimer = setTimeout(function () { saveToDB(currentWrittenWords, $('#txt').val()); }, autosaveInterval);
        }
    });

    //$('#claim-reward').click(function () {
    //    $('#achievement-unlocked').addClass('hidden');
    //    //TODO: SHOW ANIMATIONS HOW EXPERIENCE IS GROWING etc.
    //});
});


function doneTyping(newText: number): void {
    $('#written-words').text(newText);
    checkProgress(newText);
}

function checkProgress(currentWrittenWords: number): void {
    var requiredWords: number = +$("#writing-day-required-words").text();
    var percentageCompleted: number = (currentWrittenWords * 100) / requiredWords;
    var percentageFloored: number = Math.floor(percentageCompleted);

    if (percentageFloored >= 100)
    {
        percentageFloored = 100;
    }
    updateSlider(percentageFloored);
}

function updateSlider(byPercentage: number): void {
    $(".progress-slider").css("width", byPercentage + "%").css({
        transition: 'width .8s ease-in-out'});
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
        //TODO: PLAY MUSIC & ANIMATION
        $('#achievement-unlocked').removeClass('hidden');

        $.ajax({
            url: "api/IAuthorHabitAPI/" + $('#day-number').val(),
            contentType: "text/plain",
            method: "GET",
            success: function (data) {
                console.log("SUCCESSFUL CONGRATULATE");
            }
        })
        //TODO: SHOW UP ACHIEVEMENT 
        //TODO: STORE IN DB AS COMPLETED
        //TODO: ASSIGN POINTS, SHOW SKILL UP, LEVEL UP, ETC...
    }
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

function getWritingDay(pathId: number, dayId: number) {
    $.get("WritingArea/GetDay/" + pathId + "/" + dayId, function (data) {
        $("#writing-area").html(data).removeClass("writing-area-hidden");
    });
}

//View Methods

function changeMessage(message: string): void {
    $("#message-of-the-day").text(message);
    $("#hidden-message-of-the-day").removeClass('hidden-message-of-the-day');
}

function hideHiddenMessageOfTheDay()
{
    $("#hidden-message-of-the-day").addClass('hidden-message-of-the-day');
}