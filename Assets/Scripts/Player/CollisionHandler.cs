using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    Rocket spaceShip;   

    AudioSource audioSource;

    void Start()
    {
        spaceShip = GetComponent<Rocket>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (spaceShip.isTransitioning || spaceShip.collisionDisabled) { return; }

        //determines which object is colliding and what to do based upon how it's tagged
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                StartDeathSequence();                
                break;
        }
    }

    void StartSuccessSequence()
    {
        spaceShip.isTransitioning = true;
        audioSource.Stop(); //stops the thrusting sound                
        Invoke(nameof(LoadNextLevel), levelLoadDelay);
    }

    void StartDeathSequence()
    {
        spaceShip.isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(spaceShip.death);
        spaceShip.deathParticles.Play();
        Invoke(nameof(ReloadLevel), levelLoadDelay);
    }

    public void LoadNextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = ++currentLevel;

        if (nextLevel == SceneManager.sceneCountInBuildSettings)
            nextLevel = 0;

        SceneManager.LoadScene(nextLevel);
    }

    void ReloadLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
}
