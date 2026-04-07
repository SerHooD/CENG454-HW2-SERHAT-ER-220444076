using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    
    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;
    private bool isCrashed = false; 

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("Sounds/SuccessSound");
    }

    public void EnterDangerZone()
    {
        isCrashed = false; 
        threatCleared = false; 

        if (statusText != null)
        {
            statusText.text = "Entered a Dangerous Zone!";
            statusText.color = Color.red;
        }
    }

    public void ExitDangerZone()
    {
        if (isCrashed) return; 

        threatCleared = true; 

        if (audioSource != null)
            audioSource.Play();

        if (statusText != null)
        {
            statusText.text = "Safe Zone - Threat Cleared";
            statusText.color = Color.green;
        }
    }

    public void OnMissileHit()
    {
        isCrashed = true; 
        hasTakenOff = false;
        threatCleared = false;

        if (statusText != null)
        {
            statusText.text = "CRASHED! Return to runway.";
            statusText.color = Color.red;
        }
    }
}