using Ship;
using UnityEngine;

namespace Audio
{
    /// <summary>
    /// Handles the audio for the player ship
    /// </summary>
    public class PlayerAudioControl : MonoBehaviour
    {
        [SerializeField]
        private AudioSource m_audioSource;

        [SerializeField]
        private PlayerShip m_playerShip;

        [SerializeField]
        private AudioClip m_boostClip;

        [SerializeField]
        private AudioClip m_deathClip;

        private AudioControl m_audioControl;

        private void Awake()
        {
            if (!m_audioSource)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its AudioSource component.");

            if (!m_playerShip)
                Debug.LogError($"{gameObject.name} doesn't have a reference to the player ship.");

            if (!m_boostClip)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its boost audio clip.");

            if (!m_deathClip)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its death audio clip.");

            m_audioControl = new AudioControl(m_audioSource);
        }

        private void Start()
        {
            m_playerShip.OnCrash += PlayDeath;
        }

        private void LateUpdate()
        {
            if (m_playerShip && m_playerShip.Boost)
                m_audioControl.Play(m_boostClip, oneShot: true);
        }

        private void PlayDeath() => m_audioControl.Play(m_deathClip);
    }
}
