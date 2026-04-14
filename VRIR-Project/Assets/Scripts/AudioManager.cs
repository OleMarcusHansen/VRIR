using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioManager : MonoBehaviour
{
    public void PickupAudio(SelectEnterEventArgs selectEnterEventArgs)
    {
        if (selectEnterEventArgs.interactableObject.transform.GetComponent<AudioObject>())
        {
            AudioClip clip = selectEnterEventArgs.interactableObject.transform.GetComponent<AudioObject>().audioPickup;

            if (clip != null)
            {
                AudioSource.PlayClipAtPoint(clip, selectEnterEventArgs.interactableObject.transform.position);
            }
        }
    }
}
