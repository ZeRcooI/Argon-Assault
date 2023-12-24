using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float _timeTillDestroy = 3f;

    private void Start()
    {
        Destroy(gameObject, _timeTillDestroy);
    }
}