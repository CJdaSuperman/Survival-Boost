using UnityEngine;

namespace ScriptableObjects
{
    /// <summary>
    /// The data for settings of the game
    /// </summary>
    [CreateAssetMenu(fileName = "ScriptableSettings", menuName = "ScriptableSettings")]
    public class Settings : ScriptableObject
    {
        [SerializeField]
        private float m_sensitivity;

        public float Sensitivity { get => m_sensitivity; set => m_sensitivity = value; }
    }
}
