Es el mecanismo de control de este framework, define una variable privada `active` que determina si la clase que implementa la interfaz puede realizar su flujo normal de operaciones o no y dos métodos públicos:

`ToogleActive(bool)`
Fija el valor de la variable de [[Control]]

`GetActive(): bool`
Devuelve el valor de la variable `active`

Cabe decir que dentro del funcionamiento del [[Controller]], si esta clase superior se desactiva, sus [[Componentes]] de tipo [[Feature]] son desactivados y si es activado, son activados.