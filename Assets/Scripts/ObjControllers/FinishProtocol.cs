using UnityEngine;

public class FinishProtocol : MonoBehaviour
{
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem successParticles;

    AudioSource audioSource;

    private void Start() =>audioSource = GetComponent<AudioSource>();    

    void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(success);
        successParticles.Play();
    }
}
