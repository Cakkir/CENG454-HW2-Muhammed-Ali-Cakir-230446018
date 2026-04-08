using System.Collections;
using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        examManager.EnterDangerZone();

        activeCountdown = StartCoroutine(MissileCountdown());
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (activeCountdown != null)
        {
            StopCoroutine(activeCountdown);
            activeCountdown = null;
        }

        missileLauncher.DestroyActiveMissile();

        examManager.ExitDangerZone();
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);

        missileLauncher.Launch(playerTransform);
    }
}