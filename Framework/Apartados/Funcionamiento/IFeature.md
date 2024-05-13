Esta interfaz define los canales de comunicación por los que la clase controladora se comunica con la característica.

`SetupFeature(Controller)`
En este método se fijan las variables de tipo [[Configuración]] y tipo [[Propiedades]] de la característica.

`UpdateFeature(Controller)`
Este es el canal de comunicación continua del controlador con las características y viceversa.

`FeatureAction(Controller)`
Indica una acción puntual definitoria de la característica que pueda ser llamada desde el controlador.