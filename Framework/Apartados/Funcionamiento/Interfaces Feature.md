Estas interfaces definen los canales de comunicación por los que la clase controladora se comunica con la característica.

### IFeatureSetup
`SetupFeature(Controller)`
En este método se fijan las variables de tipo [[Configuración]] y tipo [[Propiedades]] de la característica.

### IFeatureUpdate
`UpdateFeature(Controller)`
Este es el canal de comunicación continua del controlador con las características y viceversa.

### IFeatureAction
`FeatureAction(Controller)`
Indica una acción puntual definitoria de la característica que pueda ser llamada desde el controlador.