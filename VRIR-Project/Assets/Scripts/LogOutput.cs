using System.Collections;
using UnityEngine;

public class LogOutput : MonoBehaviour
{
    [SerializeField] GameObject introScreen;
    [SerializeField] GameObject logOutputScreen;

    public bool yellowWarnings;
    public bool redWarnings;

    public void StartOutput()
    {

    }

    IEnumerator OutputLog()
    {
        yield return null;
    }
}
