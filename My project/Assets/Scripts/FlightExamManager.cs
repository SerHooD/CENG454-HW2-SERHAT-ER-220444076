using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    
    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    public void EnterDangerZone()
    {
        // TODO: update the mission state and HUD
        threatCleared = false; 

        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
            statusText.color = Color.red;
        }

        if (missionText != null)
        {
            missionText.text = "Threat Phase Active!";
        }
    }

    public void ExitDangerZone()
    {
        // TODO: mark the threat as cleared and refresh the HUD
        threatCleared = true; 

        if (statusText != null)
        {
            statusText.text = "Safe Zone - Threat Cleared";
            statusText.color = Color.green;
        }

        if (missionText != null)
        {
            missionText.text = "Mission: Return to Base";
        }
    }
}