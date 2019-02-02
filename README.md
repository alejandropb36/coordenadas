# Sistema de coordenadas
Clase de simulación por computadoras

*Sistemas de coordenadas

* Muestra un espacio de trabajo que representa un plano cartesiano de en donde al dar click dibuje un punto (fácilmente visible)
* La aplicacion muestra los puntos relativos a las coordenadas marcadas
* Guarda y carga las coordenadas desde un archivo .txt

### Objetivo.

El objetivo de esta actividad es saber cómo se realiza el cálculo de las coordenadas relativas por medio de las absolutas y plantearlo en software por medio de una interfaz gráfica.

---

### Marco teórico.

**Coordenadas cartesianas:**
Para entender cómo funcionan las coordenadas veremos que siguen sistema cartesiano (ejes X,Y), compuesto por un eje horizontal llamado eje X o eje de las abscisas y un eje vertical llamado eje Y o eje de las ordenadas, permite ubicar con un par de valores la posición univoca de un punto.

El punto de intersección entre el eje X y el eje Y es el punto origen, con coordenadas (0,0). Los valores sobre el eje X a la derecha son positivos y los valores a la izquierda negativos. Los valores sobre el eje Y hacia arriba son positivos y hacia abajo negativos.

**Coordenadas absolutas:**

Siguiendo el orden (x,y).

Para un punto con coordenadas 100 en el eje x y 50 en el eje y, sus coordenadas serían (100,50) como se muestra en la figura.

![Coordenada absoluta](img/coordenadas-absolutas.png
"Coordenada absoluta")

**Coordenadas cartesianas relativas:**

Son parecidas a las anteriores, pero con la diferencia de que están referidas al último punto marcado, no al origen (0,0) como las absolutas.

![Coordenada relativa](img/coordenada-relativa.png
"Coordenada relativa")

---

### Desarrollo.
El desarrollo lo realice con C# y V1isual Studio 2017, cree una interfaz gráfica de tipo Windows Form y lo trabaje mediante los eventos de los controles de la interfaz gráfica.

Lo que desarrolle fue que en un área de trabajo al momento de dar clic con el mouse en algún punto este guarda la coordenada del punto seleccionado todo lo trabajo divido entre 20 para que la coordenada seleccionada sea más representativa, de manera gráfica.

    sizeSquare = 20;
	x = e.X / sizeSquare;
    y = e.Y / sizeSquare;


Cree una clase coordenada con sus proipiedades `x` y `y`.

	class Coordenada
    {
    	int x;
        int y;

        Metodos seters y geters ...
    }
Dentro de mi programa manejo dos listas de tipo `List<Coordenada>` una la utilizo para las coordenadas absolutas y la otra para las relativas.

	list>Coordenada> absolutas;
    list>Coordenada> relativas;

Para el algoritmo de transformar de absolutas a relativas, se le asigna el primer valor de las absolutas a la lista de las relativas y este se va iterando para ir calculando la relativas con respecto a la coordenada anterior (que es básicamente la diferencia con el punto anterior).

	coordenadasRelativas(absolutas,relativa)
    {
    	int x;
        int y;
        relativas.Add(absolutas[0]);
        
        for(int i = 0; i < absolutas.Count; i++)
        {
        	Coordenada cord = new Coordenada();
            x = absolutas[i].getX - absolutas[i-1].getX;
            y = absolutas[i].getY - absolutas[i-1].getY;
            cord.setX = x;
            cord.setY = y;
            relativas.Add(cord);
        }
    }

Todo esto se guarda en un documento `.txt` con el nombre de `coordenadas.txt`.

---

### Pruebas y resultados.

**Interfaz gráfica.**
![interfaz](img/interfaz.jpg
"Interfaz gráfica del programa")

Para seleccionar algún punto hay que dar un clic del mouse sobre el área de trabajo cuadriculada.

![Punto](img/punto.jpg
"Primer punto")

Como podemos ver el punto se marca de color azul y siempre en la esquina superior izquierda del cuadrado que estemos seleccionando. Del lado izquierdo podemos ver las coordenadas absolutas y relativas, del lado inferior izquierda de toda la ventana nos muestra el valor de la última coordenada seleccionada.

![Información del punto](img/informacion-punto.png
"Información de las coordenadas")

Como podemos ver el programa funciona correctamente, nos muestra las coordenadas relativas de acuerdo con la coordenada anterior.

![Resultados](img/resultados.jpg
"Resultado del programa")

Para guardar ya que terminemos de usar el programa hay que presionar el botón de guardar y se generara un archivo llamado `coordenadas.txt`

![Guardar](img/guardar.png
"Guardar")

![Archivo](img/archivo.jpg
"Archivo generado")

Para cargar la información que contiene el archivo "`coordenadas.txt`" solo hay que presionar el botón de cargar.

---

### Conclusiones.

Esta práctica nos sirve para saber cómo manejar puntos grafico dentro de la simulación por computadora, ya que de aquí parten muchas cosas más. Ya con esta actividad se adquieren las habilidades para desarrollar los algoritmos de dibujo de líneas mucho más fácil.
