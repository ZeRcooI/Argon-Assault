using UnityEngine;

public class PlayerContols : MonoBehaviour
{
    [Header("General Setup Setting")]
    [Tooltip("XYLI NADO")] [SerializeField] private float _controlSpeed = 10f;
    [SerializeField] private float _xRange = 8f;
    [SerializeField] private float _yRange = 3.5f;

    [Header("Lazer gun array")]
    [SerializeField] private GameObject[] _lasers;

    [Header("Screen position based tuning")]
    [SerializeField] private float _positionPitchFactor = -5f;
    [SerializeField] private float _controlPitchFactor = -10f;

    [Header("Player input based tuning")]
    [SerializeField] private float _positionYawFactor = 5f;
    [SerializeField] private float _controllRollFactor = 1f;

    private float _xThrow;
    private float _yThrow;

    private void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    private void SetLasersActive(bool isActive)
    {
        foreach (GameObject lazer in _lasers)
        {
            ParticleSystem.EmissionModule emissionModule = lazer.GetComponent<ParticleSystem>().emission;

            emissionModule.enabled = isActive;
        }
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * _positionPitchFactor;
        float pitchDueToControlThrow = _yThrow * _controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * _positionYawFactor;
        float roll = _xThrow * _controllRollFactor;

        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, _controllRollFactor);
    }

    private void ProcessTranslation()
    {
        _xThrow = Input.GetAxis("Horizontal");
        _yThrow = Input.GetAxis("Vertical");

        float xOffset = _xThrow * Time.deltaTime * _controlSpeed;
        float rawXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawXPosition, -_xRange, _xRange);

        float yOffset = _yThrow * Time.deltaTime * _controlSpeed;
        float rawYPosition = transform.localPosition.y + yOffset;
        float clampedYPosition = Mathf.Clamp(rawYPosition, -_yRange, _yRange);

        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, transform.localPosition.z);
    }
}