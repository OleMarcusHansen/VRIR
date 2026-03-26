using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    [SerializeField] List<Alarm> alarms;

    [SerializeField] Lamp lamp;

    public void PlayAlarms(bool red)
    {
        foreach (Alarm alarm in alarms)
        {
            alarm.StartAlarm(red);
        }

        // change light color
        lamp.StartAlarm(red);

        // add alarm sound
    }
}
