let maxInputElementNumber = 13;

let text = `My dear old ~ sat me down to hear some words of wisdom 
\n 1. Give a man a ~ and you ~ him for a day ~ a man to ~ and he'll ~ forever 
\n 2. He who ~ at the right time can ~ again 
\n 3. Always wear ~ ~ in case you're in a ~ 
\n 4. Don't use your ~ to wipe your ~ and always have a clean ~ with you`;

let inputUserArray = [];

function madLibGenerator() {
    createInputArray();

    if (checkForMissingInput()) {
        document.getElementById('output1').value = 'Please, enter all values.';
    } else {
        createMadLibSentence();
    }
}

function createInputArray() {
    for (let i = 0; i <= maxInputElementNumber; i++) {
        inputUserArray[i] = document.getElementById('i' + i).value;
    }
}

function checkForMissingInput() {
    for (let i = 0; i < inputUserArray.length; i++) {
        if (inputUserArray[i] === "") {
            return true;
        }
    }

    return false;
}

function createMadLibSentence() {
    let madLibOutput = text.split(' ');
    let arrayIndex = 0;

    for (let i = 0; i < madLibOutput.length; i++) {
        let matchIndex = madLibOutput.indexOf('~');
        madLibOutput[matchIndex] = inputUserArray[arrayIndex];

        arrayIndex++;
    }

    document.getElementById('output1').value = madLibOutput.join(' ');
}