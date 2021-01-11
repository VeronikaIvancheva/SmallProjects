let gameRules = `Game Rules:

Each turn, a player repeatedly rolls a die until either a 1 is rolled or the player decides to "hold": 
- If the player rolls a 1, they score nothing and it becomes the next player's turn.
- If the player rolls any other number, it is added to their turn total and the player's turn continues.
- If a player chooses to "hold", their turn total is added to their score, and it becomes the next player's turn.

The first player to score 100 or more points wins. 

For example, the first player, Donald, begins a turn with a roll of 5. Donald could hold and score 5 points, but chooses to roll again. Donald rolls a 2, and could hold with a turn total of 7 points, but chooses to roll again. Donald rolls a 1, and must end his turn without scoring. The next player, Alexis, rolls the sequence 4-5-3-5-5, after which she chooses to hold, and adds her turn total of 22 points to her score. 
 `;

function rules() {
  //Print the Game rules in alert box if the '?' button is clicked
  alert(gameRules);
}

gameSetup();

function gameSetup() {

  let scores = [0, 0];
  let roundScore = 0;
  let activePlayer = 0;
  let gamePlaying = true;
  let scoresForWin = 100;

  //Reset Current scores
  document.getElementById('current0').textContent = '0';
  document.getElementById('current1').textContent = '0';
  //Reset Global scores
  document.getElementById('score0').textContent = '0';
  document.getElementById('score1').textContent = '0';
  //Reset Players names
  document.getElementById('name0').textContent = 'Player 1';
  document.getElementById('name1').textContent = 'Player 2';
  //Reset Player class
  document.querySelector('.player0').classList.remove('playerActive');
  document.querySelector('.player1').classList.remove('playerActive');
  //Remove Winner class
  document.querySelector('.player0').classList.remove('playerWinner');
  document.querySelector('.player1').classList.remove('playerWinner');

  //Set active player to 1
  document.querySelector('.player0').classList.add('playerActive');

  //Hide the dice
  document.querySelector('.dice').style.display = 'none';

  document.querySelector('.btn-roll').addEventListener('click', function () {
    if (gamePlaying) {
      //Roll random number from 00 to 6
      let dice = Math.floor(Math.random() * 6 + 1);

      //Set the Rolled dice image
      let diceDoc = document.querySelector('.dice');
      diceDoc.style.display = 'block';
      diceDoc.src = 'dice-' + dice + '.png';

      if (dice !== 1) {
        //Update the score
        roundScore += dice;

        //Update the UI
        document.querySelector('#current' + activePlayer).textContent = roundScore;
      } else {
        //Next player turn
        roundSetup();
      }
    }
  });

  document.querySelector('.btn-hold').addEventListener('click', function () {
    if (gamePlaying) {
      //Add Current score to Global score
      scores[activePlayer] += roundScore;

      //Update the UI
      document.querySelector('#score' + activePlayer).textContent = scores[activePlayer];

      //Check if player Won the game
      if (scores[activePlayer] >= scoresForWin) {
        //Change the name with Winner
        document.querySelector('#name' + activePlayer).textContent = 'WINNER!!!';
        document.querySelector('.player' + activePlayer).classList.add('playerWinner');
        document.querySelector('.player' + activePlayer).classList.remove('playerActive');

        gamePlaying = false;
      } else {
        //Next player turn
        roundSetup();
      }
    }
  });

  function roundSetup() {
    activePlayer === 0 ? (activePlayer = 1) : (activePlayer = 0);

    roundScore = 0;

    document.getElementById('current0').textContent = '0';
    document.getElementById('current1').textContent = '0';
    document.querySelector('.player0').classList.toggle('playerActive');
    document.querySelector('.player1').classList.toggle('playerActive');

    document.querySelector('.dice').style.display = 'none';
  }

  document.querySelector('.btn-new').addEventListener('click', gameSetup);
}