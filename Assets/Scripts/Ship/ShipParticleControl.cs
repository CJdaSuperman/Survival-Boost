using UnityEngine;

namespace Ship
{
    /// <summary>
    /// Controls the particle systems related to the player ship
    /// </summary>
    public class ShipParticleControl : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem m_boostParticles;

        [SerializeField]
        private ParticleSystem m_deathParticles;

        private PlayerShip m_playerShip;

        private void Awake()
        {
            if (!m_boostParticles)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its boost particles.");

            if (!m_deathParticles)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its death particles.");
        }

        private void Start()
        {
            if (!m_playerShip)
                Debug.LogError($"{name} on {gameObject.name} doesn't have a reference to the ship.");

            m_playerShip.OnCrash += Die;
        }

        private void LateUpdate()
        {
            if (m_playerShip)
                Boost(m_playerShip.Boost);
        }

        public void AssignShip(PlayerShip playerShip) => m_playerShip = playerShip;

        public void Boost(bool play)
        {
            if (play)
            {
                if (!m_boostParticles.isPlaying)
                    m_boostParticles.Play();
            }
            else
            {
                m_boostParticles.Stop();
            }
        }

        private void Die() => m_deathParticles.Play();
    }
}
