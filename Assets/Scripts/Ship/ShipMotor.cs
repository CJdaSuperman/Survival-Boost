using UnityEngine;

namespace Ship
{
    /// <summary>
    /// Handles the RigidBody related behavior of a ship
    /// </summary>
    public class ShipMotor
    {
        private Rigidbody m_rigidBody;
        private GameObject m_ship;

        public ShipMotor(GameObject ship, Rigidbody rigidBody)
        {
            m_ship = ship;
            m_rigidBody = rigidBody;
        }

        public void ApplyBoost(float force) => m_rigidBody.AddRelativeForce(Vector3.up * force * Time.deltaTime);

        public void Rotate(float rotationForce)
        {
            m_rigidBody.freezeRotation = true;    //takes manual control of rotation

            // Negate the rotational force so that the rotation goes opposite of direction
            m_ship.transform.Rotate(Vector3.forward * -rotationForce * Time.deltaTime);

            m_rigidBody.freezeRotation = false;    //resumes physics control of rotation
        }
    }
}
