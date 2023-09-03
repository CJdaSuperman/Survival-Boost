using System;
using UnityEngine;

namespace Environment
{
    /// <summary>
    /// The component that controls behavior for landing pads
    /// </summary>
    public class LandingPad : MonoBehaviour
    {
        [SerializeField]
        private AudioSource m_audioSource;

        [SerializeField]
        private ParticleSystem m_successParticles;

        public event Action OnLanded;

        private void Awake()
        {
            if (!m_audioSource)
            {
                Debug.LogError($"{gameObject.name} doesn't have a reference to its audio source component.");
            }
            else
            {
                if (!m_audioSource.clip)
                    Debug.LogError($"{gameObject.name}'s audio source doesn't have a clip to play.");
            }

            if (!m_successParticles)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its success particles.");
        }

        public void Landed()
        {
            m_audioSource.Play();
            m_successParticles.Play();
            OnLanded?.Invoke();
        }
    }
}
