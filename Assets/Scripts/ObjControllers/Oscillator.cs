using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movement;
    
    [SerializeField] float period = 2f;

    float movementFactor;

    Vector3 startingPos;    
    
    void Start() => startingPos = transform.position;   

    void Update()
    {
        if(period <= Mathf.Epsilon) { return; } //prevents a division by zero

        float cycles = Time.time / period;  //the amount of cycles you want the movement to go through is
        //the game time divided by the period--how long it takes to go through a cycle

        const float tau = Mathf.PI * 2f;
        float rawSinWave = Mathf.Sin(cycles * tau); //passes a radian value into the Mathf.Sin function

        movementFactor = rawSinWave / 2f + 0.5f;

        Vector3 offset = movement * movementFactor;

        transform.position = startingPos + offset;
    }
}
