using UnityEngine;

public class PC_Controls : MonoBehaviour
{
    [SerializeField] float rcsThrust = 45f;
    [SerializeField] float upwThrust = 630f;

    Rocket spaceship;
    
    Rigidbody rigidBody;

    CollisionHandler collisionHandler;

    AudioSource audioSource;

    void Start()
    {
        spaceship = GetComponent<Rocket>();
        rigidBody = GetComponent<Rigidbody>();
        collisionHandler = GetComponent<CollisionHandler>();
        audioSource = GetComponent<AudioSource>();
    }

    public void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            Application.Quit();
        
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            spaceship.gameManager.TogglePauseMenu();
        }
        else
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }
    }

    void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space) && !spaceship.gameManager.isGamePaused())
            ApplyThrust();
        else
            StopApplyingThrust();
    }

    void RespondToRotateInput()
    {
        if (Input.GetKey(KeyCode.A))
            ManualRotation(rcsThrust * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            ManualRotation(-rcsThrust * Time.deltaTime);
    }

    void ApplyThrust()
    {
        float thrustThisFrame = upwThrust * Time.deltaTime;

        rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);

        //plays audio while holding down the space bar
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(spaceship.mainEngine);
            spaceship.mainEngineParticles.Play();
        }        
    }

    void StopApplyingThrust()
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

    public void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
            collisionHandler.LoadNextLevel();
        else if (Input.GetKeyDown(KeyCode.C))
            spaceship.collisionDisabled = !spaceship.collisionDisabled;
    }
}
