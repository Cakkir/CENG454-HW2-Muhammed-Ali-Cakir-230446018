using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform cameraAnchor;
    [SerializeField] private Transform lookTarget;
    [SerializeField] private float followSpeed = 5f;

    private void LateUpdate()
    {
        if (cameraAnchor == null || lookTarget == null)
            return;

        transform.position = Vector3.Lerp(
            transform.position,
            cameraAnchor.position,
            followSpeed * Time.deltaTime
        );

        transform.LookAt(lookTarget.position + Vector3.up * 1.5f);
    }
}