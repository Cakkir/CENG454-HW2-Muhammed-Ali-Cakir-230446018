using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

private void OnTriggerEnter(Collider other)
{
    Debug.Log("Triggered by: " + other.name);

    if (!other.CompareTag("Missile"))
        return;

    Debug.Log("MISSILE HIT!");

    if (examManager != null)
    {
        examManager.MissileHit();
    }

    Destroy(other.gameObject);
}
}