const elements = {};

const myWords = ['cat', 'dog', 'mouse', 'bird', 'senses', 'inner', 'donkey', 'miracle', 'love', 'yourselves'];
const game = {
    array: [],
    row: 5,
    col: 5,
    width: 100,
    x: '',
    y: '',
    placedWords: [],
    boardArray: []
};


initializeGameArea();

function initializeGameArea() {
    elements.gameArea = document.querySelector('.gameArea');
    elements.message = document.createElement('div');
    elements.gridSize = document.createElement('input');
    elements.btn = document.createElement('button');
    elements.myList = document.createElement('div');
    elements.myList.classList.add('myList');
    
    elements.gridContainer = document.createElement('div');
    elements.gridContainer.classList.add('gridContainer');

    elements.gameArea.append(elements.message);
    elements.gameArea.append(elements.gridSize);
    elements.gameArea.append(elements.btn);
    elements.gameArea.append(elements.gridContainer);
    elements.gameArea.append(elements.myList);

    log('Click Play to Start the game. Select the number of cells for the grid.');
    elements.btn.textContent = 'Play';

    elements.gridSize.setAttribute('type', 'number');
    elements.gridSize.setAttribute('max', '20');
    elements.gridSize.setAttribute('min', '3');
    elements.gridSize.value = 5;

    elements.btn.addEventListener('click', startGame);
}

function startGame() {
    log('Select the grid letters');
    elements.btn.style.display = 'none';
    elements.gridSize.style.display = 'none';

    game.row = Number(elements.gridSize.value);
    game.col = Number(elements.gridSize.value);
    game.x = '';
    game.y = '';
    game.boardArray.length = 0;
    game.array.length = 0;
    game.array.length = game.row * game.col;
    game.placedWords.length = 0;

    elements.gridContainer.style.width = (game.col * game.width + 50) + 'px';

    autoGridResize();

    myWords.forEach((value, index) => {
        let template = placeWord(value);

        if (template) {
            game.placedWords.push({
                word: value,
                position: template
            });
        }
    })

    FillTheBoardWithRandomLetters();
    buildBoard();

    elements.myList.innerHTML = '';
    populatePlayerSearchList();
}

function FillTheBoardWithRandomLetters() {
    for (let i = 0; i < game.array.length; i++) {
        if (game.array[i] == '-') {
            game.array[i] = randomLetters();
        }
    }
}

function randomLetters() {
    return 'ABCDEFGHIJKLMNOPQRSTUVWXYZ'.toLowerCase().split('')[Math.floor(Math.random() * 26)];
}

function autoGridResize() {
    for (let i = 0; i < game.array.length; i++) {
        game.array[i] = '-';
    }

    for (let xx = 0; xx < game.row; xx++) {
        game.x += ' auto ';
    }

    for (let yy = 0; yy < game.row; yy++) {
        game.y += ' auto ';
    }

    elements.gridContainer.style.gridTemplateColumns = game.x;
    elements.gridContainer.style.gridTemplateRows = game.y;
}

function placeWord(word) {
    let placed = false;
    let count = 300;

    word = word = (Math.random() > 0.5) ? word : word.split('').reverse().join('');

    while (!placed && count > 0) {
        let direction = (Math.random() > 0.5) ? true : false;
        let position = {
            cols: 0,
            rows: 0
        };

        count--;

        if (direction && word.length <= game.col) {
            position.cols = findStartPosition(word.length, game.col);
            position.rows = Math.floor(Math.random() * game.row);
            placed = xPlace(position, word);
        } else if (!direction && word.length <= game.row) {
            position.rows = findStartPosition(word.length, game.row);
            position.cols = Math.floor(Math.random() * game.col);
            placed = yPlace(position, word);
        }
    }

    return placed;
}

function findStartPosition(wordValue, totalValue) {
    return Math.floor(Math.random() * (totalValue - wordValue + 1));
}

function xPlace(position, word) {
    let startPlace = (position.rows * game.col) + position.cols;
    let availableSpacesForWord = 0;
    let indexPlaced = [];

    for (let i = 0; i < word.length; i++) {
        if (game.array[startPlace + i] == '-') {
            availableSpacesForWord++;
        }
    }

    if (availableSpacesForWord == word.length) {
        for (let i = 0; i < word.length; i++) {
            if (game.array[startPlace + i] == '-') { //checking just in case
                game.array[startPlace + i] = word[i];
                indexPlaced.push(startPlace + i);
            }
        }

        return indexPlaced;
    }

    return false;
}

function yPlace(position, word) {
    let startPlace = (position.rows * game.col) + position.cols;
    let availableSpacesForWord = 0;
    let indexPlaced = [];

    for (let i = 0; i < word.length; i++) {
        if (game.array[startPlace + (i * game.col)] == '-') {
            availableSpacesForWord++;
        }
    }

    if (availableSpacesForWord == word.length) {
        for (let i = 0; i < word.length; i++) {
            if (game.array[startPlace + (i * game.col)] == '-') { //checking just in case
                game.array[startPlace + (i * game.col)] = word[i];
                indexPlaced.push(startPlace + (i * game.col));
            }
        }

        return indexPlaced;
    }

    return false;
}

function buildBoard() {
    elements.gridContainer.innerHTML = '';

    game.array.forEach((element, index) => {
        let div = document.createElement('div');
        div.textContent = element;
        div.classList.add('grid-item');
        elements.gridContainer.append(div);

        div.addEventListener('click', (e) => {
            game.boardArray[index] = true;

            let checker = {
                found: 0,
                word: ''
            };

            game.placedWords.forEach((w) => {
                if (w.position.includes(index)) {
                    checker.found++;
                    checker.word = w.word
                }
            })

            if (checker.found > 0) {
                div.style.backgroundColor = 'green';
            } else {
                div.style.backgroundColor = 'red';
            }

            foundChecker();
        })
    })
}

function foundChecker() {
    game.placedWords.forEach((word, index) => {
        let checker = 0;

        game.boardArray.forEach((value, ind) => {
            if (word.position.includes(ind)) {
                checker++;
            }
        })
        if(checker == word.word.length){
            word.element.style.color = 'red';
            word.element.style.textDecoration = 'line-through';
        };
    })

    checkWinner();
}

function checkWinner() {
    let counter = 0;
    
    game.placedWords.forEach((word, index) => {
        if(word.element.style.textDecoration == 'line-through'){
            counter++;
        }
    })
    
    let checkWordsLeft = game.placedWords.length - counter;
    log(`${checkWordsLeft} words left.`);

    if (checkWordsLeft == 0 || game.placedWords == 0) {
        log('You Won!<br>Click button to start again');
        elements.gridSize.style.display = 'inline-block';
        elements.btn.style.display = 'inline-block';
    }
}

function populatePlayerSearchList() {
    game.placedWords.forEach(word => {
        word.element = document.createElement('div');
        word.element.textContent = word.word;
        word.element.array = word.position;
        elements.myList.append(word.element);
    })
}

function log(msg) {
    elements.message.innerHTML = msg;
}