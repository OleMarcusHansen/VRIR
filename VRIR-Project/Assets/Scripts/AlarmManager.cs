using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    [SerializeField] List<Alarm> alarms;

    [SerializeField] Lamp lamp;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip yellowWarningClip;
    [SerializeField] AudioClip redWarningClip;

    public void PlayAlarms(bool red)
    {
        foreach (Alarm alarm in alarms)
        {
            alarm.StartAlarm(red);
        }

        // change light color
        lamp.StartAlarm(red);

        // add alarm sound
        if (red)
        {
            audioSource.clip = redWarningClip;
            audioSource.Play();
        }
        else
        {
            audioSource.clip = yellowWarningClip;
            audioSource.Play();
        }
    }
}
