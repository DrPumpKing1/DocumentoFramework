Diagrama abstracción del diagrama de clases UML en el cual se define la estructura de un controlador y sus características y dependencias siguiendo la [[Especificación]] y la [[Jerarquía de componentes]].

Tiene el siguiente modelo:

![[JerarquíaKimera2.drawio.png|700]]

Elementos:
1. El cubo representa el controlador.
2. Los cuadrados de línea discontinua representan el estado del controlador fragmentado en interfaces `...Entity`.
3. Los cuadros son sub controladores.
4. Los cuadrados son características.
5. Los cuadrados de línea gruesa son la característica principal de su controlador o sub controlador.
6. Los diamantes son otros componentes.

Relaciones:
1. La flecha continua sólida es **influencia**.
2. La flecha continua vacía es **llamado**.
3. La flecha discontinua sólida es **dependencia**.
4. La flecha discontinua vacía es dependencia **opcional**.
5. El círculo sólido de línea continua es una relación de **control**.
6. El diamante vacío de línea continua es **agregación**
7. El diamante sólido de línea continua es **composición**.
8. No se contempla **herencia**.