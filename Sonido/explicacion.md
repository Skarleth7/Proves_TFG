#Prueba de detección de sonido
**Objetivo:** Detectar sonido para reproducir la partitura 
##Pasos: 

**Resultado esperado:** 

El sistema debe detectar sonido o frecuencia para que siga reproduciendo. 

**Video adjunto:** [pausa_movil](./video_pausa.mp4)

**Resultado esperado:** Cuado el sistema no detenta sonido en un margen de 0.5s, la reproducción se debe detener. Si el sistema detecta sonido, continuará o empezará la reproducción. 

**Pruebas**
Se realizarón diferentes pruebas tanto en el simulador como en desde el móvil. 

**Video adjunto:** 

Al determinar el sonido mínimo que puede causar un instrumento. Se asignó la frecuencia 0.5f por defecto para realizar la comprobacón de sonido. 

[Prueba sonido](./sonido_video.mp4)
En el video se puede observar, que cuando no escuchamos sonido en poco tiempo el cursor verde cambia de color a gris, y si hay nuevamente sonido cambia de color a verde. 

Enlaces para observar de forma detallada cada elemento del video: 

[Debugger + sonido](./log_sonido.png)
[Debugger + sin sonido](./log_sin_sonido.png)
[Visualización](./video_pausa.mp4)

Por otra parte, en el siguiente video se puede obser como se visualiza al depurar en unity. 
[Unity+ sonido](./pausa.mp4)



