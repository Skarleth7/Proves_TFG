# TFG-GlassMusic 
>Este repositorio contiene todas las pruebas, implementaciones y avances desarrollados durante mi Trabajo de Fin de Grado. 
<details>
<summary> Tabla de contenidos </summary>

1. [Sobre el proyecto](#ℹ️sobre-el-proyecto)
2. [Objetivos](#objetivos)  
    2.1 [Principal](#principal)   
    2.2 [Extra](#extra)
3. [Pruebas Funcionales](#pruebas-funcionales)

    3.1 [Cambio de página/párrafo por inclinación lateral](#1-cambio-de-páginapárrafo-por-inclinación-lateral)                                                             
        3.1.1 [Pasos realizados y evolución](#pasos-realizados-y-evolución)                        
        3.1.2 [Navegación por inclinación](#navegación-por-inclinación)  
        3.1.3 [Navegación con el Acelerómetro](#navegación-con-el-acelerómetro)       
        3.1.4 [Comparativa](#comparativa)   
        3.1.5 [Demostración](#demostración)   
    3.2.[Detección de Sonido](#2-detección-de-sonido)   
        3.2.1 [Esquema Simple](#esquema-simple)    
        3.2.2 [Posibles errores](#posibles-errores)   
        3.2.3 [Demostración](#demostración-1)  
4. [Contacto](#contacto)

</details>

## ℹ️Sobre el proyecto 
El objetivo principal del proyecto fue investigar, diseñar y desarrollar las funcionalidades principales dentro de la aplicación en desarrollo de GlassMusic. 

Dichas funcionalidades se implentarón dentro de Unity, en lenguaje C#.

También se realizaron diferentes comprovaciones para el correcto funcionamiento del objetivo principal. 

## 🚩Objetivos
### Principal
El objetivo principal es el avace o retroceso de pàginas mediante la inclinación lateral del cuello. 
### Extra➕ 
Se implementó la funcionalidad de detección de sonido. 
## Tecnologías utilizadas 
Las herramientas utilizadas en el transcurso del proyecto fueron las siguientes: 
- ![Unity](https://img.shields.io/badge/-Unity-000?logo=unity&logoColor=white) 

- ![Visual estudio](https://img.shields.io/badge/Visual%20Studio%20Code-007ACC?logo=visualstudiocode&logoColor=fff&style=plastic)
- [C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=unity&logoColor=white)

- ![Android Studio](https://img.shields.io/badge/Android%20Studio-3DDC84?style=flat&logo=android-studio&logoColor=white)

<details>
<summary> Unity </summary>

És una multiplataforma de desarrollo orientada al desarrollo de videojuevos y aplicaciones interactivas. 
### Elementos claves:
Los elementos principales que tiene Unity a la hora de la implementación, són los siguientes:  
1. **Escenas:** Son los espacios donde se desarrolla el juego, como niveles o menús. Cada escena contienen los objetos que se usan en esa parte del juego.
2. **GameObjects**: Son los objetos que forman parte de la escena, como luces, cámaras o decoraciones. Son la base.
3. **Componentes**: Son las partes que se agregan a los GameObjects para darles funciones, como movimiento, sonido, físicas o scripts. Sin estos componentes los GameObjects no pueden hacer nada. 
</details>

## 🧪Pruebas Funcionales
### 1. Cambio de página/párrafo por inclinación lateral
**Objetivo:** Permitir al usuario avanzar o retroceder páginas o párrafos de una partitura sin necesidad de presionar botones ni movimientos excesivos con la cabeza, utilizando gestos sutiles basados en inclinación.

![Ejemplo de inclinación lateral](./imagenes/e_edit.jpg)

En la anterior imagen se puede obserbar una representación de inclinación lateral.
#### Pasos realizados y evolución 
Para alcanzar el objetivo propuesto, se plantearon distintas formas de implementación. Una de ellas consiste en aprovechar el eje de Z, mientras que otra se basa en el uso del acelerómetro del dispositivo móvil. 
##### Navegación por inclinación  
Al empezar a desarrollar el código se tuvo en cuenta la inclinación del eje **Z** de los cuaterniones. Con esta implementación, he logrado completar este objetivo. 

**Pasos:**
- Al inclinar la cabeza o el móvil hacia la derecha: se avanza 
- Al inclinar hacia la derecha: se retrocede 
- Se requiere mantener la inclinación 3 segundo para evitar gestos accidentales. 

Esto se implementa mediante la rotación en el Z. Si el valor supera un umbral (por ejemplo +/- 20 grados), se cuenta el tiempo mantenido y se ejecuta la acción.

##### Navegación con el Acelerómetro
El acelerómetro es un dispositivo que puede medir la aceleración o la tasa de cambio de velocidad de un objeto. Algunos móviles permiten usar el acelerómetro para detectar inclinaciones. 
En la carpeta de _Scripts_ se puede observar parte del código implementado, donde el _Input.acceleration_ permite detectar las inclinación físicas del dispositivo. 
##### Comparativa
| Criterio | Inclinación por eje Z | Acelerómetro |
|----------|-----------------------|--------------|
| Precisión| Alta (usa rotación directa de la cabeza/cámara)|Media(puede ser afectado por movimientos falsos o sacudidas)|
|Más estable | menos sensible a temblores | Menos estable ya que requiere filtrado de ruido|
|Obtención de datos |  _Transform.eulerAngles.z_ | _Input.acceleration_|
|Rendimiento | Ligero ya que solo requiere lectura de rotación | Ligero, pero puede requerir algun ajuste extra |
|Intuitivo para el usuario| Muy intuitivo, requiere inclinación ligera del cuello| Menos intuitivo y puede dispararse por error| 
|Calibración adicional | A veces sí (si el eje base esta mal orientado)| Sí, para evitar falsos positivos|

Depues de realizar la comparativa, la mejor opción es mediante el eje Z de los cuaterniones. 

**Posibles errores** 

Cuando una persona, inclina la cabeza entre 5º y 10º, es casi imperceptible, por lo cual podría generar inclinaciones involuntarias. 

|        Grados     |     Tipo de control   |  Tipo de inclinación |
|-------------------|-----------------------|----------------------|
|       5º-10º      |   Seminvoluntario     |  Leve                |
|       10º-20º     |   Volunatario         |  Moderada/Normal     |
|       20º-35º     |   Involuntario        |   Pronunciada        |
|       >=35º       |   Involuntario        |   Muy Pronunciada    |

##### Demostración 

Al determinar cuántos grados sería aceptable para evitar acciones involuntarias, se realizó pruebas en Unity donde podemos ejecutar con simuladores en el inspector. 
A continuación, se explicará el contenido de cada video correspondiente con esta sección de la carpeta _Videos/Inclinación_. 

Video: [Prueba de Inclinación](./videos/Inclinación/inclinación_móvil.mp4)

El video muestra cómo al inclinar el móvil hacia la derecha se avanza de párrafos y al inclinar hacia la izquierda retrocede párrafos. 

En la esquina inferior izquierda se visualizan la página actual y el ángulo de inclinación.




Video: [Prueba de Inclinación Unity](./videos/Inclinación/prueba_inclinacion.mp4)

El video contiene una demostración de cómo se observa cuando realizamos pruebas en unity en el apartado de _inspector_, donde podemos añadir la inclinación con la que se quiere realizar las pruebas.
En la primera parte se observa que cuando cambiamos el eje de las Z su rotación y este supera los 20º o es inferior a -20º, procede a avanzar o retrocer los párrafos en caso de estar en ese modo y las páginas en caso de estar en modo completo. 
La segunda parte del video, se puede observar como se capta los angulos y encima muestra el párrafo dónde se encuentra.


### 2. Detección de Sonido 
**Objetivo:** Permitir que la partitura se reproduzca o se pause automáticamente según si el usuario emite sonido o está en silencio.

#### Esquema simple
- Si hay sonido (tocar/silbar, cantar), la partitura sigue.
- Si hay silencio por más de 0.5 segundos, la partitura, se pausa 
- Cambio del color del cursor de seguimiento (pausa-> gris , reproduciendo->verde)

#### Posibles errores

En este caso los posibles errores, son que detecta cualquier tipo de sonido y no una nota especifica de un instrumento. Esta implementación sería un paso para poder sincronizar las notas que se tocan junto a las notas de la partitura. 

##### Demostración 
Se realizarón diferentes pruebas tanto en el simulador como en desde el móvil.

Al determinar el sonido mínimo que puede causar un instrumento. Se asignó la frecuencia 0.5f por defecto para realizar la comprobacón de sonido.

Durante las pruebas se utilizó el micrófono incorporado en el móvil para medir el sonido. Si el sistema detectaba sonido por encima del umbral mínimo establecido, la partitura de reanudaba, si se detectaba que el volumen bajaba durante 0.5 segundos, se pausaba. Las pruebas realizadas permitieron que el funcionamiento de pausa y reanudación ocurriera correctamente, sin la necesidad de tocar botones. Por otra parte, se ajustó la sensibilidad para evitar falsas detecciones causadas por ruido de fondo.  

Video: [Prueba sonido](./videos/sonido/prueba_sonido.mp4)

En el video se puede observar, que cuando no escuchamos sonido en poco tiempo el cursor verde cambia de color a gris, y si hay sonido nuevamente sonido, el cursor cambia de color a verde. 
También, se puede obserbar dos imágenes donde muetran las salidas de la consola cuando hay y no hay sonido. 

Además, en el siguiente video ([escena en unity](./videos/sonido/escena_unity_reproduccion.mp4)), se puede observar como se visualiza las pruebas dentro de unity. 
### 3. Corrección de errores 

## Contacto 
- Para cualquier duda podeis contactar con AprilSkarleth.Chavez@autonoma.cat
- Web Oficial de Glassear: https://glassear.com/  
