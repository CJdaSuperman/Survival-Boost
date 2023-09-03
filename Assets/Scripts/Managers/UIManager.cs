using UnityEngine;

namespace Managers
{
    /// <summary>
    /// Component for the GameObject to manage UI canvases
    /// </summary>
    public class UIManager : MonoBehaviour
    {
#if UNITY_ANDROID || UNITY_IOS
        [SerializeField]
        private Canvas m_mobileHUD;

        public GameObject MobileHUD { get => m_mobileHUD.gameObject; }
#endif

        [SerializeField]
        private Canvas m_pauseMenu;

        private GameObject PauseMenu { get => m_pauseMenu.gameObject; }

        private void Awake()
        {
#if UNITY_ANDROID || UNITY_IOS
            if (!m_mobileHUD)
                Debug.LogError($"{gameObject.name} doesn't have a reference to the mobile HUD.");
#endif

            if (!m_pauseMenu)
                Debug.LogError($"{gameObject.name} doesn't have a reference to the pause menu.");
        }

        private void Start()
        {
#if UNITY_ANDROID || UNITY_IOS
            MobileHUD.SetActive(true);
#endif
            PauseMenu.SetActive(false);
        }

#if UNITY_STANDALONE_WIN || UNITY_WEBGL
        private void Update()
        {
            if (InputManager.PauseGame())
                TogglePause();
        }
#endif

        public void TogglePause() => PauseMenu.SetActive(!PauseMenu.activeInHierarchy);
    }
}
