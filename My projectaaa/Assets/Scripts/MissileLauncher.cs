using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;

    private GameObject activeMissile;

    public void Launch(Transform target)
    {
        Debug.Log("Launch() called");

        if (missilePrefab == null)
        {
            Debug.LogError("Missile prefab is NOT assigned!");
            return;
        }

        if (launchPoint == null)
        {
            Debug.LogError("Launch point is NOT assigned!");
            return;
        }

        if (activeMissile != null)
        {
            Destroy(activeMissile);
        }

        activeMissile = Instantiate(
            missilePrefab,
            launchPoint.position,
            launchPoint.rotation
        );

        Debug.Log("Missile instantiated: " + activeMissile.name);

        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();

        if (homing != null)
        {
            homing.SetTarget(target);
            Debug.Log("Target assigned to missile");
        }
        else
        {
            Debug.LogError("MissileHoming component missing on prefab!");
        }
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
        }
    }
}