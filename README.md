# PIPO
Program for the Investigation of Pursuing Objectives (in different creatures)

## Project for
* Intelligent Systems
* Intelligent Interfaces

## Authors
* Pamela Jiménez Rebenaque alu0100894325@ull.edu.es
* Airam Manuel Navas Simón alu0100618426@ull.edu.es
* Kevin Díaz Marrero       alu0100880625@ull.edu.es
* Jorge Sierra Acosta      alu0100896282@ull.edu.es

## Records
[APK](https://drive.google.com/open?id=17g7tYbH74dhN2F856hqu6T8tr_TGyBYk)

[UnityNEAT](https://github.com/lordjesus/UnityNEAT)

[Game Unity project](https://drive.google.com/open?id=14U_4lWqVm_CRe3-H6riQn8gs2PSN_TZT)

[Training Unity project](https://drive.google.com/open?id=1qarURAvm1PKqzQ4ALgHL78Q3IwuzzoCy)

## Folders
* Scripts: Scripts used in the project (+ NEAT scripts)
* Slides & Doc: Slides and report used in Intelligent Systems

## Project summary
The project is based on the creation of a controlled virtual reality game with a command, where the player must go through different scenarios (similar to labyrinths), avoiding traps and enemies, and collecting lives and points.

Specifically, we will be chased by different creatures that will have two senses to analyze their environment: sight and hearing and then the possibility of adding the sense of smell has been considered.

They will have several neural networks that will not be created arbitrarily, but through genetic algorithms.

## Questions of use:

The use of this application is simple.

For installation, just download the apk that is in the repository on our mobile and install it. In addition to the glasses, you need a GamePad connected to the mobile device to move around in the game and we can crouch in the game by physically bending over thanks to the mobile accelerometer. In addition, producing sound through the microphone can be detected by the enemies within the game.

When executing, a menu appears with the three scenarios to which we can access. To select one, we must place the pointer of the grid in one of them for a few seconds. After this, a loading screen will appear.

Once the game starts, our objective will be to escape the enemies while we avoid the hidden traps on the ground (which will take away life if we step on them), we collect life containers (that will add life to a total of 100 life points), and we get points.

If an enemy or our HP (life points) catches up to us, we will have died and the Game Over screen will appear that will allow us to exit the game or return to the main menu.

## Milestones achieved and highlights
* Design of three own scenarios (barn, hospital and ship) with menus (start, end of departure and load screen).
  * Ambient sounds (music and characters) and effects.
  * Use of particle systems (fire, points and lives).
* Character design and animations.
  * Different enemies for each scenario.
* Movement of the character for exploration and pursuit through the neural network.
  * Pseudorandom behavior for enemies in each game.
* Sight and hearing sensor.
* Use of Android sensors.
  * Accelerometer: the character we control crouches if the person playing also does so, reducing their speed and sound emitted.
  * Microphone: the sound is detected by microphone and its range on the stage.
* Events implemented by controller.
  * Collection of lives and points (appear again randomly in the possible positions).
  * Activation of traps.
  * Death of the player.
  * Player caught by enemy.
* Virtual Reality in Google Cardboard.
* Option selection by reticle.
* Control of change of lights.
* Control of disparity in perception between the real world and the game.

## Authors and distribution of tasks

* Kevin
  * Search for assets.
  * Animation
  * Decoration of scenarios.
  * Interaction with buttons in VR.
  * Use of sensors (accelerometer).
  * Game Over screen design.
* Airam
  * Search for assets.
  * Modeling
  * Design and decoration of scenarios.
  * Union of scenes.
  * Use of sensors (microphone).
  * Implementation of the ear sensor.
  * Addition of ambient sounds and music.
  * Game Over screen design.
* Pamela
  * Search for assets.
  * Event control.
  * Design of traps, lives and points.
  * Design and decoration of maps.
  * Load screen design.
  * Scene change control.
* Jorge
  * Search for assets.
  * Configuration of neural networks.
  * Training of neural networks.
  * Design of the training map of neural networks.
  * Programming environmental scripts.
  * Implementation of the sight sensor.
  * Search for assets of environmental sounds.

## Algunas imágenes
![Img0](https://rawgit.com/Ediolot/pipo/master/Images/img0.png)
![Img1](https://rawgit.com/Ediolot/pipo/master/Images/img1.png)
![Img2](https://rawgit.com/Ediolot/pipo/master/Images/img2.png)
