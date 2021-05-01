using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] public AudioClip mainEngine;   
    [SerializeField] public AudioClip death;
    [SerializeField] public ParticleSystem mainEngineParticles;      
    [SerializeField] public ParticleSystem deathParticles;  

    PC_Controls pcControls;

    MobileControls mControls;

    public GameManager gameManager;

    public bool isTransitioning { get; set; } = false;
    public bool collisionDisabled { get; set; } = false;  

    void Start()
    {
        pcControls = GetComponent<PC_Controls>();
        mControls = GetComponent<MobileControls>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(!isTransitioning)
        {
            if (!gameManager.isMobileControls())
            {
                pcControls.ProcessInput();
                gameManager.ActivateMobileButtons(false);
            } 
            else
            {
                mControls.ProcessInput();
                gameManager.ActivateMobileButtons(true);
            }
        }            
        
        if (Debug.isDebugBuild)  //when you're in Development Build in Unity under Build Settings
            pcControls.RespondToDebugKeys();
    }
}
