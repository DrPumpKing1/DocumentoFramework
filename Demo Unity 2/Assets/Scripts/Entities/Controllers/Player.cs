using Features;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Controller, InputEntity, KineticEntity, TerrainEntity, LivingEntity
{
    //States
    //Input
    public Vector2 inputDirection { get; set; }
    public Vector3 playerForward { get; set; }
    public Camera playerCamera { get; set; }
    //Kinetic
    public float currentSpeed { get; set; }
    //Terrain
    public bool onGround { get; set; }
    public bool onSlope { get; set; }
    //Living
    public int currentHealth { get; set; }
    public int maxHealth { get; set; }

    private void OnEnable()
    {
        SearchFeature<Life>().OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        SearchFeature<Life>().OnDeath -= OnDeath;
    }

    public override void Setup()
    {
        playerCamera = Camera.main;

        base.Setup();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();
        inputDirection = new Vector2(direction.x, direction.y);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed) CallFeature<Features.Jump>();
    }

    public void OnDeath()
    {
        ToggleActive(false);
    }
}
