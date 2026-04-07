using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;
    private AudioSource hitAudioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitAudioSource = GetComponent<AudioSource>();
        hitAudioSource.clip = Resources.Load<AudioClip>("Sounds/ExplosionSound");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            hitAudioSource.Play();

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;

            if (examManager != null)
                examManager.OnMissileHit();
        }
    }
}