using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;

    private AudioSource launchAudioSource;
    private GameObject activeMissile;

    void Start()
    {
        launchAudioSource = GetComponent<AudioSource>();
        launchAudioSource.clip = Resources.Load<AudioClip>("Sounds/MissileLaunchSound");
    }

    public GameObject Launch(Transform target)
    {
        if (activeMissile != null)
            DestroyActiveMissile();

        activeMissile = Instantiate(missilePrefab,
                                    launchPoint.position,
                                    launchPoint.rotation);

        MissileHoming homing = activeMissile.GetComponent<MissileHoming>();
        if (homing != null)
            homing.SetTarget(target);

        if (launchAudioSource != null)
        {
            launchAudioSource.clip = Resources.Load<AudioClip>("Sounds/MissileLaunchSound");
            launchAudioSource.Play();
        }

        return activeMissile;
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}