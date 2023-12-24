using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _loadDelay = 1f;
    [SerializeField] private ParticleSystem _crashEffect;

    private void OnTriggerEnter(Collider other)
    {
        StartCreashSequence();
    }

    private void StartCreashSequence()
    {
        _crashEffect.Play();

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerContols>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;

        Invoke(nameof(ReloadLevel), _loadDelay);
    }

    private void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}