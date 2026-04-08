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
        Debug.Log("DangerZone trigger enter: " + other.name);

        if (!other.CompareTag("Player"))
            return;

        Debug.Log("Player entered danger zone");

        examManager.EnterDangerZone();

        activeCountdown = StartCoroutine(MissileCountdown());
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("DangerZone trigger exit: " + other.name);

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
        Debug.Log("Missile countdown started");

        yield return new WaitForSeconds(missileDelay);

        Debug.Log("Launching missile now");

        missileLauncher.Launch(playerTransform);
    }
}