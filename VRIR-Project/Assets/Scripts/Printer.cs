using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Printer : MonoBehaviour
{
    [SerializeField] Transform printSpawn;
    [SerializeField] GameObject logPrefab;

    bool isPrinting;

    public UnityEvent onPrint;

    public void StartPrintLog()
    {
        if (isPrinting)
        {
            return;
        }

        onPrint.Invoke();
        StartCoroutine("PrintLog");
    }

    IEnumerator PrintLog()
    {
        isPrinting = true;

        yield return new WaitForSeconds(0.8f);

        Instantiate(logPrefab, printSpawn);

        yield return new WaitForSeconds(0.8f);

        Instantiate(logPrefab, printSpawn);

        yield return new WaitForSeconds(0.8f);

        Instantiate(logPrefab, printSpawn);

        isPrinting = false;
        yield return null;
    }
}
