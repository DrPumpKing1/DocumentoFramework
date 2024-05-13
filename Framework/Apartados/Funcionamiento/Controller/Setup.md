Ocurre al inicio del gameplay, en este canal que ocurre en el método `SetupFeatures()` del controlador, se llama al método `SetupFeature(Controller)`  con parámetro este controlador a todas las características que guarda el controlador.

Esto resulta en que las características tomen la variable [[Configuración]] y [[Propiedades]] en base a su controlador.