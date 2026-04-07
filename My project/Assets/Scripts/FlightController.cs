using UnityEngine;

// CENG 454 – HW1: Sky-High Prototype
// Author: Serhat Er | Student ID: [220444076]
public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f; 
    [SerializeField] private float yawSpeed = 45f;   
    [SerializeField] private float rollSpeed = 45f;  
    [SerializeField] private float thrustSpeed = 45f; 

    // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-B): Cache GetComponent() into 'rb'.
        rb = GetComponent<Rigidbody>();

        
        if (rb != null)
        {
            rb.freezeRotation = true;
           
            rb.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }

    void Update() 
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // TODO (Task 3-C):
        
        float pitchInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.deltaTime);

        
        float yawInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.deltaTime);

        
        float rollInput = 0f;
        if (Input.GetKey(KeyCode.Q)) rollInput = 1f;
        else if (Input.GetKey(KeyCode.E)) rollInput = -1f;

        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime);
    }

    private void HandleThrust()
    {
        // TODO (Task 3-D): Spacebar forward thrust
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}