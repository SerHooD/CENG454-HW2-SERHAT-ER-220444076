using UnityEngine;

public class LandingController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private bool isTakeoffArea = false;

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (isTakeoffArea)
            examManager.OnTakeoff();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!isTakeoffArea)
            examManager.OnLanding();
    }
}