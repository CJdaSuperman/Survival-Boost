using UnityEngine;

namespace Environment
{
    /// <summary>
    /// The behavior for how objects can move to a specified Vector3 position
    /// </summary>
    public class ObjectMover : MonoBehaviour
    {
        [Tooltip("The target position to move object to")]
        [SerializeField]
        Vector3 m_target;

        [SerializeField]
        float m_speed;

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, m_target, m_speed * Time.deltaTime);
        }
    }
}
