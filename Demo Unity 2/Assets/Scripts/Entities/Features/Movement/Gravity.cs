using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Features
{
    public class Gravity : MonoBehaviour, IActivable, IFeatureSetup, IFeatureFixedUpdate //Other channels
    {
        //Configuration
        [Header("Settings")]
        public Settings settings;
        //Control
        [Header("Control")]
        [SerializeField] private bool active;
        //States
        //Properties
        [Header("Properties")]
        public float gravityValue;
        public float maxVerticalSpeed;
        //References
        [Header("References")] [SerializeField]
        private List<TerrainModifier> terrains;
        //Componentes
        [Header("Components")]
        public Rigidbody cmp_rigidbody;

        private void Awake()
        {
            //Setup References
            terrains = new List<TerrainModifier>(GetComponents<TerrainModifier>());
            terrains.Sort(TerrainModifier.CompareByOrder);

            //Setup Components
            cmp_rigidbody = GetComponent<Rigidbody>();
        }

        public void SetupFeature(Controller controller)
        {
            settings = controller.settings;

            //Setup Properties
            gravityValue = settings.Search("gravityValue");
            maxVerticalSpeed = settings.Search("maxVerticalSpeed");

            ToggleActive(true);
        }

        public bool GetActive()
        {
            return active;
        }

        public void ToggleActive(bool active)
        {
            this.active = active;
        }

        public void FixedUpdateFeature(Controller controller)
        {
            if (!active) return;

            LimitVerticalSpeed();

            TerrainEntity terrain = controller as TerrainEntity;
            if (terrain == null) return;
            
            ApplyGravity(terrain);
        }

        public void ApplyGravity(TerrainEntity terrain)
        {
            bool grounded = terrain.onGround;
            bool onSlope = terrain.onSlope;

            if (grounded && !onSlope) return;

            Vector3 direction = Vector3.up;

            terrains.Sort(TerrainModifier.CompareByOrder);
            if (terrains.Count > 0) if (terrains[^1].OnTerrain) direction = terrains[terrains.Count - 1].GetTerrainNormal();

            cmp_rigidbody.AddForce(-gravityValue * Time.fixedDeltaTime * direction, ForceMode.VelocityChange);
        }

        public void LimitVerticalSpeed()
        {
            if (Mathf.Abs(cmp_rigidbody.velocity.y) <= maxVerticalSpeed) return;

            cmp_rigidbody.velocity = new Vector3(cmp_rigidbody.velocity.x, maxVerticalSpeed * Mathf.Sign(cmp_rigidbody.velocity.y), cmp_rigidbody.velocity.z);
        }
    }
}

