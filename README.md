# Practica Calificada 4 - Computación Gráfica

## Título del Juego: Sounds

## Equipo: 
- Luna Jaramillo, Christian Giovanni
- Osorio Tello, Jesús Diego

## Detalles del juego
- Juego 2D hecho por Unity

## Mecánicas:
- **Space**: Salta
- **A**: Se mueve a la izquierda
- **D**: Se mueve a la derecha
- **W**: Escala
- **Left Shift**: Planea
- **Left Click**: Golpe a la izquierda
- **Right Click**: Golpe a la derecha

## Idea principal del Juego
En una familia olvidaron meter una fruta a la refri, esta misma por temor a podrirse, en medio de la noche tendrá que ir a oscuras hacia la refrigeradora teniendo que evadir a las moscas las cuales al picarle aumentarán su porcentaje de Descomposición, en el transcurso del camino, sus amigos le empezarán a avisar de sobre que clase de piso está a punto de caer por lo que será necesario estar atentos a cualquier cambio del sonido.

## Frase: Está tan difícil que puedo resolverlo con los ojos cerrados
Para este proyecto, mi compañero y yo no nos tomamos tan literal la frase en sino que más que nada implementamos el uso del sonido como pieza fundamental en la resolución del juego, como por ejemplo en los siguientes puntos:
- Las moscas serán de un color oscuro a tal punto que podría perderse en algunas partes del escenario y aparecer repentinamente en cualquier lado, por lo que para matarlas y evitar ser mordidas, debemos de estar atentos de si el zumbido de la mosca proviene de la izquierda o de la derecha, para así poder reaccionar y golpear. Al inicio del juego no se verá tan útil estar atento al sonido pero con el transcurso del nivel, las moscas aumentan su velocidad por lo que ahora depender de nuestra vista no es una gran idea así que se tendrá que optar por reaccionar de acuerdo al sonido.
- No todos los pisos sobre los que caminemos serán estables, pero al tener un limitado campo de visión no sabremos en cual caeremos, por lo que nuestros amigos nos avisarán antes de pisar, que debemos de hacer, esto se implementa ya que si o si uno estará atento a no ser atacado por las moscas, y como en el juego queremos explotar el uso del audio como pieza clave en la resolución del juego, lo mejor sería no necesariamente estar concentrados de en donde pisas sino en que instrucción te darán tus aliados para así tener una mejor reacción y no depender de la visión.

## Instrucciones en voz
- **Salta**: Nos indicará que el siguiente piso es inestable y se caerá al tocarlo
- **Vuela**: Nos indicará que hay un lugar seguro más adelante por lo que debemos de realizar la acción de planear
- **Sube**: Nos indicará que nos encontramos o nos acercamos en una escalera y debemos de subir para llegar al siguiente piso

## Fuentes:
- [Sprite de Escalera](https://es.pngtree.com/freepng/retro-8-bit-ladder-icon-with-transparent-background-vector_21022250.html)

- [Sonidos](https://pixabay.com/es/sound-effects/search/win/)

- [Fondo de pantalla](https://www.freepik.es/fotos-vectores-gratis/fondos-pantalla-gta-san-andreas-articulos-cocina)

- [Gizmos](https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Gizmos.html)