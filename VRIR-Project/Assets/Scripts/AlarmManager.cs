using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    [SerializeField] List<Alarm> alarms;

    public void PlayAlarms(bool red)
    {
        foreach (Alarm alarm in alarms)
        {
            alarm.StartAlarm(red);
        }

        // change light color


        // add alarm sound
    }
}
