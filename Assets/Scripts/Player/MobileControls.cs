using UnityEngine;

public class MobileControls : MonoBehaviour
{
    [SerializeField] float rcsThrust = 45f;
    [SerializeField] float upwThrust = 630f;

    Rocket spaceship;

    Rigidbody rigidBody;

    AudioSource audioSource;

    GameManager gameManager;

    void Start()
    {
        spaceship = GetComponent<Rocket>();
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ProcessInput()
    {
        Touch dragFinger;

        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {                
                if(Input.touchCount > 1)    //if two fingers on screen
                {
                    dragFinger = Input.GetTouch(1);

                    if (dragFinger.phase == TouchPhase.Moved)
                    {
                        if (dragFinger.deltaPosition.x < 0)
                            ManualRotation(rcsThrust * Time.deltaTime);
                        else
                            ManualRotation(-rcsThrust * Time.deltaTime);
                    }
                }       
                else
                {
                    if(!gameManager.thrustButtonHandler.PointerDown)
                    {
                        dragFinger = Input.GetTouch(0);

                        if (dragFinger.phase == TouchPhase.Moved)
                        {
                            if (dragFinger.deltaPosition.x < 0)
                                ManualRotation(rcsThrust * Time.deltaTime);
                            else
                                ManualRotation(-rcsThrust * Time.deltaTime);
                        }
                    }
                }
            }
        }
    }

    public void ApplyThrust()
    {
        float thrustThisFrame = upwThrust * Time.deltaTime;

        rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(spaceship.mainEngine);
            spaceship.mainEngineParticles.Play();
        }        
    }

    public void StopApplyingThrust()
    {
        audioSource.Stop();
        spaceship.mainEngineParticles.Stop();
    }

    void ManualRotation(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true;    //takes manual control of rotation

        transform.Rotate(Vector3.forward * rotationThisFrame);

        rigidBody.freezeRotation = false;    //resumes physics control of rotation
    }
}
