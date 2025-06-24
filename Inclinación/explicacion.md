#Prueba cambio de página

**Objetivo:** Interacción por gestos 

##Pasos: 

**Resultado esperado:** Avanzar o retroceder las páginas o párrafos de las partituras sin necesidad de tocar un botón o mover demasiado la cabaza.

**Pruebas**

**- Primer bloque:** 
Al empezar a desarrollar el codigo se tuvo en cuenta la inclinación del eje **Z** de los cuaterniones. Con esta implementación, he logrado completar este objetivo.

**- Segundo bloque:**
Para realizar test visuales, se tuvo en cuenta el accelerometrp del móvil. 

Al crear el archivo, se tuvo que crear nuevas conexiones con archivos nuevos donde recogen los valores. 
El archivo original que se creó en el primer bloque no se modificó:

**Inclinación**

En las siguientes imágenes se puede observar la inclinación que haría una persona con 20º o 45º
[Inclinación de 20º](./Inclinacion%20lateral.png)
[Inclinación de 30º](./inclinacion_cabeza.jpg)

Cuando una persona, inclina la cabeza entre 5º y 15º, es casi imperceptible, por lo cual podría generar inclinaciones involuntarias. 

**Video adjunto:** 

Al determinar cuántos grados sería aceptable para evitar acciones involuntarias, se realizó pruebas en Unity donde podemos ejecutar con simuladores en el inspector. 

[Prueba de Inclinación](./prueva_unity.mp4)
En la primera parte se observa que cuando cambiamos el eje de las Z su rotación y este supera los 20º o es inferior a -20º, procede a avanzar o retrocer los párrafos en caso de estar en ese modo y las páginas en caso de estar en modo completo. 
La segunda parte del video, se puede observar como se capta los angulos y encima muestra el párrafo dónde se encuentra.
