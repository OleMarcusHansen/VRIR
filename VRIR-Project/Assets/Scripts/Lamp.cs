using System.Collections;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] Light spotLight;

    public void StartAlarm(bool red)
    {
        if (!red)
        {
            StartCoroutine("PlayYellowAlarm");
        }
        else
        {
            StartCoroutine("PlayRedAlarm");
        }
    }

    IEnumerator PlayYellowAlarm()
    {
        spotLight.color = Color.yellow;

        yield return new WaitForSeconds(0.4f);

        spotLight.color = Color.white;
    }
    IEnumerator PlayRedAlarm()
    {
        spotLight.color = Color.red;

        yield return new WaitForSeconds(0.4f);

        spotLight.color = Color.white;
    }
}
