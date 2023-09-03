using Environment;
using Managers;
using System;
using UnityEngine;

namespace Ship
{
    /// <summary>
    /// Handles the frame-by-frame update and collision of the player ship 
    /// </summary>
    public class PlayerShip : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody m_rigidBody;

        [SerializeField]
        private ShipParticleControl m_particles;

        [SerializeField]
        [Tooltip("The amount of vertical force to apply to ship")]
        private float m_vForce;

        [SerializeField]
        [Tooltip("The amount of rotation force to apply to ship")]
        private float m_rForce;

        private ShipMotor m_motor;

        private float m_rotationDirection;             // The direction to rotate ship

        public bool Boost { get; private set; }        // Flag to apply vertical force
        
        public float RotationSensitivity { get; set; } // The sensitivity to rotate

        public event Action OnCrash;

        private void Awake()
        {
            if (!m_rigidBody)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its RigidBody component.");

            m_motor = new ShipMotor(gameObject, m_rigidBody);
            m_particles.AssignShip(this);
        }

        private void FixedUpdate()
        {
            if (Boost)
                m_motor.ApplyBoost(m_vForce);

            m_motor.Rotate(m_rotationDirection * m_rForce);
        }

        private void Update()
        {
#if UNITY_STANDALONE_WIN || UNITY_WEBGL
            Boost = InputManager.IsBoosting();
            m_rotationDirection = InputManager.RotationDirection(RotationSensitivity);
#elif UNITY_ANDROID || UNITY_IOS
            m_rotationDirection = InputManager.RotationDirection(Boost, RotationSensitivity);
#endif
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!enabled) return;

            GameObject other = collision.gameObject;

            if (other.TryGetComponent(out LandingPad landingPad))
            {
                enabled = false;
                landingPad.Landed();
            }
            else if (other.TryGetComponent(out Checkpoint checkpoint))
            {
                // TODO
            }
            else
            {
                enabled = false;
                OnCrash?.Invoke();
            }
        }

#if UNITY_ANDROID || UNITY_IOS
    public void ApplyBoost(bool state) => Boost = state;
#endif
    }
}
