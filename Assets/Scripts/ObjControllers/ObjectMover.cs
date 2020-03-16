using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Tooltip("How many units to offset object by")] [SerializeField] Vector3 offset;

    [SerializeField] float speed;

    void Update() => transform.position = Vector3.MoveTowards(transform.position, offset, speed);
}
