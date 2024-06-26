Diagrama abstracción del diagrama de clases UML en el cual se define la estructura de un controlador y sus características y dependencias siguiendo la [[Especificación]] y la [[Jerarquía de componentes]].

Cabe decir que es un diagrama que se alienta a usar con el grado de abstracción que vean conveniente los usuarios.

Tiene el siguiente modelo:

![[JerarquíaKimera.drawio.png]]

Elementos:
1. El cubo representa el controlador.
2. El cubo de línea discontinua representa referencias a controladores externos.
3. Los cuadrados de línea discontinua representan el estado del controlador fragmentado en interfaces `...Entity`.
4. Los frames son sub controladores.
5. Los rectángulos son características.
6. Los rectángulos de línea gruesa señalan la característica principal de su controlador o sub controlador.
7. Los diamantes son otros componentes.
8. El archivo representa clases externas con referencias estáticas.

Relaciones:
1. La flecha continua sólida es **asociación dirigida**.
2. La línea continua es **asociación**
3. La flecha continua vacía es **herencia**.
4. La flecha discontinua sólida es **dependencia**.
5. La flecha discontinua vacía es **dependencia opcional**.
6. El círculo sólido de línea continua es una relación de **control**.
7. El diamante vacío de línea continua es **agregación**
8. El diamante sólido de línea continua es **composición**.

### Leyenda

![[LeyendaJerarquíaKimera.drawio.png]]