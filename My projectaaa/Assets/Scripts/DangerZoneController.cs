using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        examManager.EnterDangerZone();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        examManager.ExitDangerZone();
    }
}