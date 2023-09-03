using Ship;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI.Buttons
{
    /// <summary>
    /// The behavior for the Boost button in Mobile ports
    /// </summary>
    public class BoostButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
#if UNITY_ANDROID || UNITY_IOS
        [SerializeField]
        private PlayerShip m_playerShip;

        private void Awake()
        {
            if (!m_playerShip)
                Debug.LogError($"{gameObject.name} doesn't have a reference to the player ship.");
        }

        public void OnPointerDown(PointerEventData eventData) => m_playerShip.ApplyBoost(true);

        public void OnPointerUp(PointerEventData eventData) => m_playerShip.ApplyBoost(false);
#else
        public void OnPointerDown(PointerEventData eventData) => Debug.LogError("Button click should not be enabled on Windows platforms.");

        public void OnPointerUp(PointerEventData eventData) => Debug.LogError("Button click should not be enabled on Windows platforms.");
#endif
    }
}
