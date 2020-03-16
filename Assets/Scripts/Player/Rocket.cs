using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 45f; 
    [SerializeField] float upwThrust = 630f;

    [SerializeField] public float levelLoadDelay = 1f;

    [SerializeField] AudioClip mainEngine;   
    [SerializeField] public AudioClip death;
    [SerializeField] ParticleSystem mainEngineParticles;      
    [SerializeField] public ParticleSystem deathParticles;

    Rigidbody rigidBody;
    AudioSource audioSource;

    CollisionHandler collisionHandler;

    public bool isTransitioning { get; set; } = false;
    public bool collisionDisabled { get; set; } = false;  

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        collisionHandler = GetComponent<CollisionHandler>();
    }

    void Update()
    {
        if(!isTransitioning)
            ProcessInput();
        if (Debug.isDebugBuild)  //when you're in Development Build in Unity under Build Settings
            RespondToDebugKeys();
    }

    void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }            
        else
        {
            RespondToThrustInput();
            RespondToRotateInput();
        }        
    }    

    void RespondToThrustInput()
    {
        if (Input.GetKey(KeyCode.Space))        
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
            audioSource.PlayOneShot(mainEngine);

        mainEngineParticles.Play();
    }

    void StopApplyingThrust()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }

    void ManualRotation(float rotationThisFrame)
    {
        rigidBody.freezeRotation = true;    //takes manual control of rotation

        transform.Rotate(Vector3.forward * rotationThisFrame);

        rigidBody.freezeRotation = false;    //resumes physics control of rotation
    }        

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))     
            collisionHandler.LoadNextLevel();
        else if (Input.GetKeyDown(KeyCode.C))
            collisionDisabled = !collisionDisabled;
    }
}
