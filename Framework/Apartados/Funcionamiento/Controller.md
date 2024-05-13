El controlador es una clase abstracta que agrupa varias características y mantiene un seguimiento de estas y permite que estas operen de forma coordinada. Además contiene un estado interno especificado por variables de tipo [[Estado]] que permitirá las características de tipo respuesta reflejar este estado interno de forma estética.

El controlador además de los especificado, presenta tres canales para la comunicación con las características que lo componen:

| Orden | Canal              |
| ----- | ------------------ |
| 1     | [[Setup]]          |
| 2     | [[Update]]         |
| 3     | [[Call To Action]] |

Además la variable [[Estado]] del controlador es ligeramente más compleja que la de las características. Véase [[Estado del Controller]]

Cabe decir que el controlador no tiene comportamiento por sí mismo.