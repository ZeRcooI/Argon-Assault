using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffects;
    [SerializeField] private GameObject _hitEffects;

    [SerializeField] private int _scoreHit = 15;
    [SerializeField] private int _hitPoint = 1;

    private ScoreBoard _scoreBoard;
    private GameObject _parentGameObject;

    private void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
        _parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if (_hitPoint < 1)
        {
            KillEnemy();
        }
    }

    private void AddRigidbody()
    {
        Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.useGravity = false;
    }

    private void ProcessHit()
    {
        GameObject effects = Instantiate(_hitEffects, transform.position, Quaternion.identity);

        effects.transform.parent = _parentGameObject.transform;

        Destroy(gameObject);

        _hitPoint--;
    }

    private void KillEnemy()
    {
        _scoreBoard.IncreaseScore(_scoreHit);

        GameObject effects = Instantiate(_deathEffects, transform.position, Quaternion.identity);

        effects.transform.parent = _parentGameObject.transform;

        Destroy(gameObject);
    }
}