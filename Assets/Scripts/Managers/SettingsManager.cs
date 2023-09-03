using ScriptableObjects;
using Ship;
using UnityEngine;

namespace Managers
{
    /// <summary>
    /// The centralized access and storage of settings
    /// </summary>
    public class SettingsManager : MonoBehaviour
    {
        [SerializeField]
        private Settings m_settings;

        [SerializeField]
        private PlayerShip m_playerShip;

        public float Sensitivity { get => m_settings.Sensitivity; }

        private void Start()
        {
            if (!m_settings)
                Debug.LogError($"{gameObject.name} doesn't have a reference to the settings.");

            if (!m_playerShip)
                Debug.LogError($"{gameObject.name} doesn't have a reference to the player ship.");

            m_playerShip.RotationSensitivity = m_settings.Sensitivity;
        }

        public void UpdateSenstivity(float sensitivity)
        {
            m_settings.Sensitivity = sensitivity;
            m_playerShip.RotationSensitivity = sensitivity;
        }
    }
}
