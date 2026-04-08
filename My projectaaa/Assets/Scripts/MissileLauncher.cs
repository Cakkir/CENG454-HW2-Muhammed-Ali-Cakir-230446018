using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;

    private GameObject activeMissile;

    public void Launch(Transform target)
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
        }

        activeMissile = Instantiate(
            missilePrefab,
            launchPoint.position,
            launchPoint.rotation
        );

        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();

        if (homing != null)
        {
            homing.SetTarget(target);
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