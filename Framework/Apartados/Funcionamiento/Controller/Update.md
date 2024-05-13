En este canal suceden dos cosas:
- Las características que requieren refresco continuo para funcionar, dicho de otra manera, se ejecutan continuamente, completan su acción por medio de la información tanto de las variables de [[Estado]] como de [[Referencias]] del controlador. Ello pueden ser características de respuesta actualizando elementos estéticos del juego como otras de corte más funcional necesitando información del paso del tiempo, posición de terceras entidades, etc.
- Las características con la información de su estado interno actualizan el estado del controlador.

De forma más precisa en este canal, mientras esté activo el controlador, se llama el método `UpdateFeature(Controller)` de cada característica de la entidad.