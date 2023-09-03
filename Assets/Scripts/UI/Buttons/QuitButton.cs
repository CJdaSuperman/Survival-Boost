using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    /// <summary>
    /// The behavior for the Quit button
    /// </summary>
    public class QuitButton : MonoBehaviour
    {
        [SerializeField]
        private Button m_button;

        private void Awake()
        {
            if (!m_button)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its button.");
        }

        private void Start()
        {
            m_button.onClick.AddListener(() => Application.Quit());
        }
    }
}
