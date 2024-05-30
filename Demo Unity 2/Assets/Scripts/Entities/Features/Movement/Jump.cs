using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Features
{
    public class Jump : MonoBehaviour, IActivable, IFeatureSetup, IFeatureUpdate, IFeatureAction
    {
        //Configuration
        [Header("Settings")]
        public Settings settings;
        //Control
        [Header("Control")]
        [SerializeField] private bool active;
        //States
        [Header("States")]
        //States / Time Management
        [SerializeField] private float jumpTimer;
        //Properties
        [Header("Properties")]
        public float jumpForce;
        //Properties / Time Management
        public float jumpCooldown;
        //References
        //Componentes
        [Header("Components")]
        [SerializeField] private Rigidbody cmp_rigidbody;

        private void Awake()
        {
            //Setup Components
            cmp_rigidbody = GetComponent<Rigidbody>();
        }

        public void SetupFeature(Controller controller)
        {
            settings = controller.settings;

            //Setup Properties
            jumpForce = settings.Search("jumpForce");
            jumpCooldown = settings.Search("jumpCooldown");

            ToggleActive(true);
        }

        public void UpdateFeature(Controller controller)
        {
            if (jumpTimer > 0) jumpTimer -= Time.deltaTime;
        }

        public void FeatureAction(Controller controller, params Setting[] settings)
        {
            if (!active) return;

            if(cmp_rigidbody == null) return;
            if (jumpTimer > 0) return;

            cmp_rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
            jumpTimer = jumpCooldown;
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
}

