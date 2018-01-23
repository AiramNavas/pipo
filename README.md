# PIPO
Program for the Investigation of Pursuing Objectives (in different creatures)

## Proyecto para
* Sistemas Inteligentes
* Interfaces Inteligentes

## Archivos
[APK](https://drive.google.com/open?id=17g7tYbH74dhN2F856hqu6T8tr_TGyBYk)

[UnityNEAT](https://github.com/lordjesus/UnityNEAT)

[Game Unity project](https://drive.google.com/open?id=14U_4lWqVm_CRe3-H6riQn8gs2PSN_TZT)

[Training Unity project](https://drive.google.com/open?id=1qarURAvm1PKqzQ4ALgHL78Q3IwuzzoCy)

## Carpetas
* Scripts: Scripts used in the project (+ NEAT scripts)
* Slides & Doc: Slides and document about the IA

## Resumen del proyecto
El proyecto se basa en la creación de un juego de realidad virtual controlado con un mando, donde el jugador deberá recorrer distintos escenarios (similares a laberintos), evadiendo trampas y enemigos, y recogiendo vidas y puntos.

En concreto, nos perseguirán distintas criaturas que contarán con dos sentidos para analizar su entorno: vista y oído y posteriormente se ha barajado la posibilidad de añadir el sentido del olfato.

Dispondrán, de varias redes neuronales que no serán creadas de forma arbitraria, sino a través de algoritmos genéticos.

## Cuestiones de uso:

La utilización de esta aplicación es sencilla.

Para su instalación, solo debemos descargar el apk que se encuentra en el repositorio en nuestro móvil e instalarla. Además de las gafas, se necesita un GamePad conectado al dispositivo móvil para poder desplazarnos en el videojuego.

Al ejecutar, aparece un menú con los tres escenarios a los que podemos acceder. Para seleccionar uno, debemos situar el puntero de la retícula en uno de ellos durante unos segundos. Tras esto, aparecerá una pantalla de carga.

Una vez comience el juego, nuestro objetivo será escapar de los enemigos mientras esquivamos las trampas ocultas en el suelo (que nos restarán vida si las pisamos), recogemos contenedores de vida (que nos sumarán vida hasta un total de 100 puntos de vida), y conseguimos puntos.

Si nos atrapa un enemigo o nuestro HP (puntos de vida) llega a 0, habremos muerto y aparecerá la pantalla de Game Over que nos permitirá salir del juego o volver al menú principal.
