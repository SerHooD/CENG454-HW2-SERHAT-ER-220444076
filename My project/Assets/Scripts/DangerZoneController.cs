using UnityEngine;
using System.Collections; 


public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher; 
    [SerializeField] private float missileDelay = 5f;
    
    private Coroutine activeCountdown;

    private void OnTriggerEnter(Collider collision)
    {
        // TODO: confirm the Player tag
        if (collision.CompareTag("Player"))
        {
            // TODO: push the warning message "Entered a Dangerous Zone!" to the HUD
            examManager.EnterDangerZone();
            
            // TODO: start the delayed missile launch countdown
            activeCountdown = StartCoroutine(MissileLaunchRoutine());
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        // TODO: confirm the Player tag
        if (collision.CompareTag("Player"))
        {
            // TODO: cancel any pending launch countdown
            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
                Debug.Log("Missile countdown cancelled safely.");
            }
            
            // TODO: destroy the active missile and clear the HUD warning
            examManager.ExitDangerZone();
            
            
        }
    }

    private IEnumerator MissileLaunchRoutine()
    {
        yield return new WaitForSeconds(missileDelay);
        Debug.Log("Missile Launched!"); 
        
    }
}