# AnAdventureGame

Remember the classic game Monkey Island, well here you can remember the dialogue duel.

**Gameplay explanation**

This game is about the dialogue duel. Two characters, player stands on the left and the enemy on the right. On the first quarrel, the starting character i selected randomly, and the other must comeback correctly. If the player comebacks correctly, the enemy loses a life, if the player mistakes, player loses a life, on the next quarrel the previous winner starts. Both characters have up to 3 lifes, when the life score gets to 0, the game is over and the player will get a message if he wins.

There are 3 scenes in the game:
- MainMenu: first scene, you can chose to start or to quit.
- Game: where the main loop is, it can be paused.
- EndGame: final scene, the result is given and you can retry or go to main menu.

**Creation process**

It is a game based on UI elements, most of the game objects are buttons and text.

_Main Menu_

You will find only 2 buttons and a background image. The button PLAY makes the player start the game and go to game scene, EXIT button just quits the application, each of them have its script attached.

_Game_

As said before, the main loop happens here. Canvas is divided in two parts: visual section (life score and animations) and the playable section (buttons box for player). The scripts used in this scene are:

- AllSentences: contains all the dialogue lines divided in flame and comeback sentence, also the correct comebacks are assigned.
- GameplayManager: main script. The buttons box is created, if player has to flame he gets the flame buttons, if he has to comeback he gets the comeback buttons. The parameters values are saved and will be used in the EndGame scene.
- AnimationPlayer: player character animations parameters.
- AnimationEnemy: enemy character animations parameters.
- PauseMenuManager: responsible for activating the pause menu, it only has the methods for the buttons.

_EndGame_

Final scene, the result is given and two buttons are shwon: RETRY and MENU. These two buttons uses the same scripts as the MainMenu's.

You can see the result in this video: https://youtu.be/j9hL4zx85m0
