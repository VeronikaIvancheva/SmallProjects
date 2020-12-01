const textElement = document.getElementById('text');
const optionButtonsElement = document.getElementById('option-buttons');

let state = {};

function startGame() {
    state = {};
    showTextNode(1);
}

function showTextNode(textNodeIndex) {
    const textNode = textNodes.find(textNode => textNode.id === textNodeIndex);
    textElement.innerText = textNode.text;

    while (optionButtonsElement.firstChild) {
        optionButtonsElement.removeChild(optionButtonsElement.firstChild)
    }

    textNode.options.forEach(option => {
        if (showOption(option)) {
            const button = document.createElement('button');
            button.innerText = option.text;
            button.classList.add('btn');
            button.addEventListener('click', () => selectOption(option))
            optionButtonsElement.appendChild(button);
        }
    })
}

function showOption(option) {
    return option.requiredState == null || option.requiredState(state);
}

function selectOption(option) {
    const nextTextNodeId = option.nextText;

    if (nextTextNodeId <= 0) {
        return startGame();
    }

    state = Object.assign(state, option.setState);
    showTextNode(nextTextNodeId);
}

const textNodes = [{
        id: 1,
        text: 'You wake up in a quiet forest with a birds singing and a noise from water coming from somewhere not so far away. On the ground near you you see a heart-shaped stone.',
        options: [{
                text: 'Take the stone',
                setState: {
                    heartShapedStone: true
                },
                nextText: 2,
            },
            {
                text: 'Leave it there',
                nextText: 2,
            }
        ]
    },
    {
        id: 2,
        text: 'You venture forth in search of the river since you are thirsty when you came across a fairy. She asks you anxiously if you have seen a heart-shaped stone.',
        options: [{
                text: 'Show the stone.',
                requiredState: (currentState) => currentState.heartShapedStone,
                nextText: 3,
            },
            {
                text: 'You point out the direction where you came from and move forwards.',
                nextText: 4,
            }
        ]
    },
    {
        id: 3,
        text: 'The fairy is so grateful that she decides to give you reward. She offers you a sword or a shield. What will you choose?',
        options: [{
                text: 'Get the sword',
                requiredState: (currentState) => currentState.heartShapedStone,
                setState: {
                    heartShapedStone: false,
                    sword: true
                },
                nextText: 4,
            },
            {
                text: 'Get the shield',
                requiredState: (currentState) => currentState.heartShapedStone,
                setState: {
                    heartShapedStone: false,
                    shield: true
                },
                nextText: 4,
            }
        ]
    },
    {
        id: 4,
        text: 'After a few minutes you come across a shallow river. You bend down and drink a few handfuls of water when you notice something glittering at the bottom.',
        options: [{
                text: 'Leave it there.',
                nextText: 16,
            },
            {
                text: 'Take it.',
                nextText: 5,
            }
        ]
    },
    {
        id: 5,
        text: 'You put your hand in the water and take out a blue-green glass. You look at it for a few seconds until you notice that your fingers are starting to turn gray.',
        options: [{
                text: 'Keep looking at it.',
                nextText: 6,
            },
            {
                text: 'Drop in down.',
                nextText: 7,
            },
            {
                text: 'Put it in your pocket.',
                nextText: 7,
            }
        ]
    },
    {
        id: 6,
        text: 'You keep gnawing at the stone for a few seconds. There is something enchanting about it. You sense something strange and look across the river and notice something disappearing into the bushes. Near this place you see something like a statue that looks very much like a man. When you look closer, you realize that this is really a person holding a stone like the one that was in your hand. You try to drop it down but your body feels heavy. You cannot control your fingers and you start to feel ill. You did not wake up anymore.',
        options: [{
                text: 'Restart the game',
                nextText: -1,
            }
        ]
    },
    {
        id: 7,
        text: 'You watch your fingers for a few seconds, but they stay that way. Since the grayness does not spread, you forget about the stone and take a look around. You look across the river and notice something disappearing into the bushes. Near this place you see something like a statue that looks very much like a man. When you look closer, you realize that this is really a person holding a stone like the one that was in your hand. You step back and turn around, but you almost collide with the old woman behind you. You did not understand when she approached. What are you going to do?',
        options: [{
                text: 'Try to talk to her.',
                nextText: 9,
            },
            {
                text: 'Run away.',
                nextText: 8,
            }
        ]
    },
    {
        id: 8,
        text: 'You pass her quickly and start running, but you feel heaviness in your chest and fall to the ground. You did not wake up anymore.',
        options: [{
            text: 'Restart the game',
            nextText: -1,
        }]
    },
    {
        id: 9,
        text: 'You look at her and smile. "Do you know anything about those stones in the river?" you ask her. She just looks at you, but after a few seconds she sighs and says, "You should not have touched the stone. It is enchanted and if you walk away from the river you will lose consciousness and die. If you want to save yourself you have to go after the creature you saw from the other side of the river. " "The thing that hid in the bushes?" you ask. "Yes." "But you said that I do not have to wander far away from the river." "Hide nearby and wait for him to reappear." Then she turns and disappears from your sight.',
        options: [{
                text: 'Do as she said.',
                nextText: 11,

            },
            {
                text: 'Ignore her warning.',
                nextText: 10,

            }
        ]
    },
    {
        id: 10,
        text: 'You decide to ignore her words - after all what a old woman knows? You walk away and after a minute you feel heaviness in your chest. You find yourself on the ground. Everything went blurry. You did not wake up anymore.',
        options: [{
            text: 'Restart the game',
            nextText: -1,
        }]
    },
    {
        id: 11,
        text: 'You cross the river and find yourself a hiding spot. After a few minutes you saw a little deer-like creature walking outside of the forest. It stops near the river and start drinking. What will you do?',
        options: [{
                text: 'Jump out with your sword pointed out to it.',
                requiredState: (currentState) => currentState.sword,
                nextText: 13,
            },
            {
                text: 'Try sneak to it and catch it.',
                nextText: 12,
            },
            {
                text: 'Try talk to it.',
                nextText: 13,
            }
        ]
    },
    {
        id: 13,
        text: 'You scared it away. You hide again, regretting your stupidity, but the creature no longer appears. The time passes and you start to starve. You die of starvation.',
        options: [{
                text: 'Restart the game',
                nextText: -1,
            }
        ]
    },
    {
        id: 12,
        text: 'You catch it and you see that it is afraid of you. What will you do?',
        options: [{
                text: 'Try talk to it and calm it down.',
                nextText: 15,
            },{
                text: 'Point your sword at it.',
                nextText: 14,
            }
        ]
    },
    {
        id: 14,
        text: 'The creature makes a writing-like sound and the whole forest dies down. You feel the hairs on your neck stand on end, but before you can turn around, a fog descends on you and you did not wake up anymore.',
        options: [{
                text: 'Restart the game',
                nextText: -1,
            }
        ]
    },
    {
        id: 15,
        text: 'You are not sure if that is going to work but you start talk to it in a calm voice. Eventually the creature calms down and look into your eyes. You hesitate, but decide to let it go. It takes a few steps back and make a little bow. "So many of your kind decide to try and kill me. Only a few did not try to go that way. Since I see that your heart did not hold into violence I will let you go. Go with peace. The magic is lifted." Still stunned you watch as it go away. Your fingers are back to normal.',
        options: [{
                text: 'Continue your journey',
                nextText: 16,
            }
        ]
    },
    {
        id: 16,
        text: 'You notice a narrow path and go to that way. After a while you see a little town. You feel tired. What are you going to do?',
        options: [
            {
              text: 'Find a room to sleep at in the town',
              nextText: 17
            },
            {
              text: 'Find some hay in a stable to sleep in',
              nextText: 18
            }
        ]
    },
    {
      id: 17,
      text: 'Without any money to buy a room you break into the nearest inn and fall asleep. After a few hours of sleep the owner of the inn finds you and has the town guard lock you in a cell.',
      options: [
        {
          text: 'Restart the game',
          nextText: -1
        }
      ]
    },
    {
      id: 18,
      text: 'You wake up well rested and full of energy ready to go and explore the town.',
      options: [
        {
          text: 'Explore the town',
          nextText: 19
        }
      ]
    },
    ,
    {
      id: 18,
      text: 'To be continue...',
    },
]

startGame()