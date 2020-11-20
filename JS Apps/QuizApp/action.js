const gameArea = document.querySelector('.gameArea');
const question = document.createElement('div');

const btn = document.createElement('button');
const btnNext = document.createElement('button');

const message = document.createElement('div');
message.textContent = 'Click the button to start the game';
message.classList.add('message');

const player = {
    questions: 0,
    correct: 0,
    incorrect: 0,
    total: 0
};

const game = {
    data: {},
    current: ''
};

btn.textContent = 'Start Game';
btnNext.textContent = 'Next Question';
btnNext.style.display = 'none';

gameArea.append(message);
gameArea.append(question);
gameArea.append(btn);
gameArea.append(btnNext);

btn.addEventListener('click', startGame);
btnNext.addEventListener('click', loadNextQuestion);

function startGame() {
    btn.style.display = 'none';
    message.textContent = '';

    player.total = 0;
    player.questions = 0;
    player.correct = 0;
    player.incorrect = 0;

    loadQuizData('quiz.json');
    scoreBoard();
}

function scoreBoard() {
    message.innerHTML =`Questions ${player.questions} out of ${player.total}
    <br>Correct (${player.correct}) Wrong (${player.incorrect})`;
}

function loadQuizData(url) {
    fetch(url)
        .then(response => {
            return response.json();
        })
        .then(json => {
            game.data = json.data;
            player.total = game.data.length;
            loadNextQuestion();
        })
}

function loadNextQuestion() {
    if (game.data.length !== 0) {
        player.questions++;
        game.current = game.data.shift();
        createGame(game.current);
    } else {
        question.innerHTML = 'Game Over. No more questions';
        btnNext.style.display = 'none';
    }

    scoreBoard();
}

function createGame(value) {
    question.innerHTML = '';
    btnNext.style.display = 'none';

    const div = document.createElement('div');
    div.textContent = value.question;
    div.classList.add('question');
    question.append(div);

    const divHolder = document.createElement('div');
    divHolder.classList.add('answer');
    question.append(divHolder);

    const answer = value.options;
    answer.push(value.answer);
    answer.sort(() => {
        return 0.5 - Math.random();
    })

    answer.forEach(element => {
        const span = document.createElement('span');
        span.textContent = element;
        span.classList.add('box');
        span.classList.add('boxA');
        divHolder.append(span);

        span.addEventListener('click', (e) => {
            const elementBox = document.querySelectorAll('.box');
            elementBox.forEach((boxElement) => {
                boxElement.classList.remove('boxA');
                boxElement.style.backgroundColor = '#ddd';
            })

            if (element == value.answer) {
                player.correct++;
                span.style.backgroundColor = 'greenyellow';
            } else {
                player.incorrect++;
                span.style.backgroundColor = 'red';
            }

            scoreBoard();

            btnNext.style.display = 'block';
            divHolder.addEventListener('click', (e) => {
                e.stopPropagation();
            }, true);
        })
    });
}