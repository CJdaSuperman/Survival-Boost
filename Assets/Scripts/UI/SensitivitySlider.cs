using Managers;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    /// <summary>
    /// Handles the slider for sensitivity
    /// </summary>
    public class SensitivitySlider : MonoBehaviour
    {
        [SerializeField]
        private Slider m_slider;

        [SerializeField]
        private SettingsManager m_settings;

        private void Start()
        {
            if (!m_slider)
                Debug.LogError($"{gameObject.name} doesn't have a reference to its slider.");

            if (!m_settings)
                Debug.LogError($"{gameObject.name} doesn't have a reference to settings.");

            m_slider.value = m_settings.Sensitivity;
            m_slider.onValueChanged.AddListener(OnUpdate);
        }

        private void OnUpdate(float value) => m_settings.UpdateSenstivity(value);
    }
}
