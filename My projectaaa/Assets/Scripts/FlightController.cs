using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 45f;
    [SerializeField] private float rollSpeed = 45f;
    [SerializeField] private float thrustSpeed = 5f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.freezeRotation = true;
        }
    }

    private void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        float pitchInput = Input.GetAxis("Vertical");
        float yawInput = Input.GetAxis("Horizontal");

        float rollInput = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            rollInput = 1f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rollInput = -1f;
        }

        float pitchAmount = pitchInput * pitchSpeed * Time.deltaTime;
        float yawAmount = yawInput * yawSpeed * Time.deltaTime;
        float rollAmount = rollInput * rollSpeed * Time.deltaTime;

        transform.Rotate(pitchAmount, yawAmount, rollAmount);
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float moveAmount = thrustSpeed * Time.deltaTime;
            transform.Translate(Vector3.forward * moveAmount);
        }
    }
}