using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    /// <summary>
    /// The behavior for the PauseMenu button in Mobile ports
    /// </summary>
    public class MobilePauseMenuButton : MonoBehaviour
    {
#if UNITY_ANDROID || UNITY_IOS
        [SerializeField]
        private Button m_button;

        [SerializeField]
        private UIManager m_uiManager;

        private void Awake()
        {
            if (!m_button)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its button.");

            if (!m_uiManager)
                Debug.LogError($"{gameObject.name} doesn't have a reference to the UI manager.");
        }

        private void Start()
        {
            m_button.onClick.AddListener(m_uiManager.TogglePause);
        }
#endif
    }
}
