using Environment;
using Ship;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Handles the transitioning between scenes
/// </summary>
public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    private PlayerShip m_playerShip;

    [SerializeField]
    private LandingPad m_landingPad;

    [SerializeField] 
    private float m_levelLoadDelay;

    private WaitForSeconds m_delay;

    private void Awake()
    {
        if (!m_playerShip)
            Debug.LogError($"{gameObject.name} doesn't have a reference to the player ship.");

        if (!m_landingPad)
            Debug.LogError($"{gameObject.name} doesn't have a reference to the landing pad.");

        m_delay = new WaitForSeconds(m_levelLoadDelay);
    }

    private void Start()
    {
        m_playerShip.OnCrash += OnCrash;
        m_landingPad.OnLanded += OnLanded;
    }

    private void OnCrash() => StartCoroutine(ReloadScene());

    private void OnLanded() => StartCoroutine(LoadNextScene());
    
    private IEnumerator LoadNextScene()
    {
        yield return m_delay;

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = ++currentLevel;

        if (nextLevel == SceneManager.sceneCountInBuildSettings)
            Application.Quit();

        SceneManager.LoadScene(nextLevel);
    }

    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(m_levelLoadDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
