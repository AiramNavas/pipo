# PIPO
Program for the Investigation of Pursuing Objectives (in different creatures)

## Proyecto para
* Sistemas Inteligentes
* Interfaces Inteligentes

## Autores
* Pamela Jiménez Rebenaque alu0100894325@ull.edu.es
* Airam Manuel Navas Simón alu0100618426@ull.edu.es
* Kevin Díaz Marrero       alu0100880625@ull.edu.es
* Jorge Sierra Acosta      alu0100896282@ull.edu.es

## Archivos
[APK](https://drive.google.com/open?id=17g7tYbH74dhN2F856hqu6T8tr_TGyBYk)

[UnityNEAT](https://github.com/lordjesus/UnityNEAT)

[Game Unity project](https://drive.google.com/open?id=14U_4lWqVm_CRe3-H6riQn8gs2PSN_TZT)

[Training Unity project](https://drive.google.com/open?id=1qarURAvm1PKqzQ4ALgHL78Q3IwuzzoCy)

## Carpetas
* Scripts: Scripts usados en el proyecto (+ NEAT scripts)
* Slides & Doc: Diapositivas e informe utilizado en Sistemas Inteligentes

## Resumen del proyecto
El proyecto se basa en la creación de un juego de realidad virtual controlado con un mando, donde el jugador deberá recorrer distintos escenarios (similares a laberintos), evadiendo trampas y enemigos, y recogiendo vidas y puntos.

En concreto, nos perseguirán distintas criaturas que contarán con dos sentidos para analizar su entorno: vista y oído y posteriormente se ha barajado la posibilidad de añadir el sentido del olfato.

Dispondrán, de varias redes neuronales que no serán creadas de forma arbitraria, sino a través de algoritmos genéticos.

## Cuestiones de uso:

La utilización de esta aplicación es sencilla.

Para su instalación, solo debemos descargar el apk que se encuentra en el repositorio en nuestro móvil e instalarla. Además de las gafas, se necesita un GamePad conectado al dispositivo móvil para poder desplazarnos en el videojuego y podremos agacharnos en el juego agachándonos físicamente gracias al acelerómetro del móvil. Además producir sonido por el micrófono podrá ser detectado por los enemigos dentro del juego.

Al ejecutar, aparece un menú con los tres escenarios a los que podemos acceder. Para seleccionar uno, debemos situar el puntero de la retícula en uno de ellos durante unos segundos. Tras esto, aparecerá una pantalla de carga.

Una vez comience el juego, nuestro objetivo será escapar de los enemigos mientras esquivamos las trampas ocultas en el suelo (que nos restarán vida si las pisamos), recogemos contenedores de vida (que nos sumarán vida hasta un total de 100 puntos de vida), y conseguimos puntos.

Si nos atrapa un enemigo o nuestro HP (puntos de vida) llega a 0, habremos muerto y aparecerá la pantalla de Game Over que nos permitirá salir del juego o volver al menú principal.

## Hitos conseguidos
* Diseño de tres escenarios  propios (granero, hospital y nave) con menús (inicio, fin de partida y.pantalla de carga).
  * Sonidos ambientales (música y personajes) y efectos.
  * Utilización de sistemas de partículas (fuego, puntos y vidas).
* Diseño de personajes y animaciones.
* Movimiento del personaje para exploración y persecución mediante la red neuronal.
* Sensor de vista y oído.
* Utilización de sensores de Android.
  * Acelerómetro: el personaje que controlamos se agacha si la persona jugando también lo hace, reduciendo su velocidad y sonido emitido.
  * Micrófono: se detecta el sonido por micrófono y su rango en el escenario.
* Eventos implementados mediante controlador.
  * Recogida de vidas y puntos.
  * Activación de trampas.
  * Muerte del jugador.
  * Jugador atrapado por enemigo.
* Realidad Virtual en Google Cardboard.
* Selección de opción mediante retícula.
* Control de cambio de luces.
* Control de disparidad en la percepción entre el mundo real y el juego.

## Autores y reparto de tareas

* Kevin
  * Búsqueda de assets.
  * Animación.
  * Decoración de escenarios.
  * Interacción con botones en VR.
  * Uso de sensores (acelerómetro).
  * Diseño de pantalla de Game Over.
* Airam
  * Búsqueda de assets.
  * Modelado.
  * Diseño y decoración de escenarios.
  * Unión de escenas.
  * Uso de sensores (micrófono).
  * Implementación del sensor de oído.
  * Adición de sonidos ambientales y música.
  * Diseño de pantalla de Game Over.
* Pamela
  * Búsqueda de assets.
  * Control de eventos.
  * Diseño de trampas, vidas y puntos.
  * Diseño y decoración de mapas.
  * Diseño de pantalla de carga.
  * Control de cambio de escena.
* Jorge
  * Búsqueda de assets.
  * Configuración de las redes neuronales.
  * Entrenamiento de las redes neuronales.
  * Diseño del mapa de entrenamiento de las redes neuronales.
  * Programación de scripts ambientales.
  * Implementación del sensor de vista.
  * Búsqueda de assets de sonidos ambientales.

## Algunas imágenes
![Img0](https://rawgit.com/Ediolot/pipo/master/Images/img0.png)
![Img1](https://rawgit.com/Ediolot/pipo/master/Images/img1.png)
![Img2](https://rawgit.com/Ediolot/pipo/master/Images/img2.png)
