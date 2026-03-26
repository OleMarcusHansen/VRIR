using System.Collections;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;

public class Alarm : MonoBehaviour
{
    [SerializeField] MeshRenderer meshRenderer;

    [SerializeField] List<Material> normalMaterials;
    [SerializeField] List<Material> yellowMaterials;
    [SerializeField] List<Material> redMaterials;

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
        meshRenderer.SetMaterials(yellowMaterials);

        yield return new WaitForSeconds(0.4f);

        meshRenderer.SetMaterials(normalMaterials);
    }
    IEnumerator PlayRedAlarm()
    {
        meshRenderer.SetMaterials(redMaterials);

        yield return new WaitForSeconds(0.4f);

        meshRenderer.SetMaterials(normalMaterials);
    }
}
