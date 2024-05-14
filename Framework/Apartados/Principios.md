Kimera se desarrolla en la aplicación de varios principios:
1. La aplicación de **MVC** y **SOLID** para programación de videojuegos con un enfoque a componentes.
2. **Code once, run everywhere** el lema de Java que lo aplicamos para las características. Por decir, la característica movimiento de una entidad jugador y una entidad enemigo terrestre en un juego FPS podrían ser la misma.
3. **Plug and Play** como con el hardware, se enfoca en que cada característica se pueda enchufar y usar directamente en virtualmente cualquier controlador gracias a la abstención de **hardcodear** dependencias entre controladores y características.
4. **Cadena de responsabilidades**, se alienta su uso por decir, junto con los dos principios previamente mencionados se espera que los comportamientos más complejos de los sistemas de juego de las entidades surjan de cadenas de características. Por decir, en un enemigo con movimiento por el terreno gracias a una inteligencia artificial sencilla, seguiría la cadena
	1. Movimiento
	2. Modo de Movimiento
		1. Modo de Movimiento orbitando
		2. Modo de Movimiento paseando
		3. Modo de Movimiento persiguiendo
		4. Modo de Movimiento alejando
	3. Inteligencia de Movimiento
	4. Inteligencia de Manada
	Mismo movimiento que se puede estar usando en el jugador.
5. **Zero conflicto**, internamente y con otros sistemas, por eso usamos inteligentemente la herencia y aplicamos sobre todo el uso de interfaces. 