using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Printer : MonoBehaviour
{
    [SerializeField] Transform printSpawn;
    [SerializeField] GameObject logPrefab;
    [SerializeField] AudioSource audioSource;

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
        audioSource.Play();

        //yield return new WaitForSeconds(2.75f);
        yield return new WaitForSeconds(.3f);

        Instantiate(logPrefab, printSpawn);

        //yield return new WaitForSeconds(.4f);
        yield return new WaitForSeconds(1.2f);

        Instantiate(logPrefab, printSpawn);

        //yield return new WaitForSeconds(.4f);
        //yield return new WaitForSeconds(.9f);

        //Instantiate(logPrefab, printSpawn);

        isPrinting = false;
        yield return null;
    }
}
