Este apartado va a dedicado a la implementación en Unity

Se muestra la siguiente característica:

`Movement.cs`
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour, IActivable, IFeatureSetup, IFeatureFixedUpdate
{
    //Configuracion
    public Settings settings;

    //Control
    private bool active;

    //Estado
    private float speed;

    //Propiedades
    public float maxSpeed;
    public float acceleration;

    //Referencias

    //Componentes
    public Rigidbody2D cmp_rb;

    private void Awake()
    {
        cmp_rb = GetComponent<Rigidbody2D>();
    }

    public void SetupFeature(Controller controller)
    {
        this.settings = controller.settings;

        this.maxSpeed = settings.Search("maxSpeed");
        this.acceleration = settings.Search("acceleration");

        ToggleActive(true);
    }

    public void FixedUpdateFeature(Controller controller)
    {
        if(!active) return;

        InputEntity inputController = controller as InputEntity;

        float horizontal = inputController.direction.x;
        Move(horizontal);
        LimitSpeed();

        KineticEntity kineticController = controller as KineticEntity;

        UpdateControllerSpeed(kineticController);
    }

    private void Move(float horizontal)
    {
        if (horizontal == 0) return;

        Vector2 moveSpeed = Vector2.right * horizontal;

        cmp_rb.AddForce(moveSpeed.normalized * acceleration);
    }

    private void LimitSpeed()
    {
        if (Mathf.Abs(cmp_rb.velocity.x) <= maxSpeed) return;

        cmp_rb.velocity = new Vector3(Mathf.Sign(cmp_rb.velocity.x) * maxSpeed, cmp_rb.velocity.y);
    }

    private void UpdateControllerSpeed(KineticEntity kinetic)
    {
        this.speed = cmp_rb.velocity.x;

        if (kinetic == null) return;

        kinetic.speed = this.speed;
    }

    public bool GetActive()
    {
        return active;
    }

    public void ToggleActive(bool active)
    {
        this.active = active;
    }
}

```

Tomando como referencia esta característica, vamos a dar los pasos y notas para escribir características en general:

### Paso 1 Declarar herencia e interfaces

`public class Movement : MonoBehaviour, IActivable, IFeatureSetup, IFeatureFixedUpdate`

Como clase padre es necesario que sea la clase `MonoBehaviour` de Unity para poder ser usado como componente, en las interfaces son obligatorias `IActivable` e `IFeatureSetup`, de ahí usamos las que nos sean útiles para el comportamiento de la característica, en este caso `IFeatureFixedUpdate`, que es una versión de `IFeatureUpdate` específica para eventos de física de Unity.

### Paso 2 Declaramos las variables que vamos a utilizar con el acceso adecuado

Y de acuerdo a los [[Tipos de Variables]] hay que tener ciertos cuidados:
1. [[Estado]]: Pensar de antemano las variables que definen el estado de la característica, no debe estar ligado necesariamente al estado del controlador.
2. [[Propiedades]]: Definir las variables que se requiere añadir a la configuración para que esta característica funcione apropiadamente.
3. [[Referencias]]: Ver si hay referencias, cadenas de responsabilidades o dependencias opcionales o requeridas con otras características. Se alienta tener la menor o nula cantidad de dependencias obligatorias de este tipo.
4. [[Componentes]]: Ver sobre qué componentes actúa o de cuales es influenciado la característica. También revisar si son dependencias opcionales o requeridas.

### Pase 3 Implementar Lógica de Unity

Se recomienda usar únicamente el `Awake, Start, OnEnable, OnDisable` ya que el `Update` y el `FixedUpdate` se manejan desde el controlador asignado.

### Paso 4 Implementar [[IActivable]]

Con la variable de control creada puedes modificarla desde `ToggleActive` y obtenerla desde `GetActive`, pero podrías añadir otra lógica de ser necesario.

### Paso 5 Implementar IFeatureSetup

En el [[Setup]] deben ocurrir tres cosas como mínimo:
1. Pasar la variable [[Configuración]] del controlador a la característica
2. Asignar las variables [[Propiedades]] desde las configuraciones
3. Activar la característica con `ToggleActive` de [[IActivable]]

Se puede añadir lógica adicional

### Paso 6 Implementar los otros canales de comunicación elegidos

Aquí se da libertad al programador, pero se recomienda crear funciones a parte que manejen las acciones puntuales de la característica en base a los estados del controlador u otras variables y hacer los **casting** o extracción de esas variables en la lógica de los canales. Es importante no olvidan los mecanismo de control.


Ver [[Template Feature]]