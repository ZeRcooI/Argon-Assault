using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _deathEffects;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _scoreHit = 15;

    private ScoreBoard _scoreBoard;

    private void Start()
    {
        _scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        KillEnemy();
    }

    private void ProcessHit()
    {
        _scoreBoard.IncreaseScore(_scoreHit);
    }

    private void KillEnemy()
    {
        GameObject effects = Instantiate(_deathEffects, transform.position, Quaternion.identity);

        effects.transform.parent = _parent;

        Destroy(gameObject);
    }
}