using UnityEngine;

public class AudioOnCollision : MonoBehaviour
{
    [SerializeField] float minMagnitude = 2;
    [SerializeField] AudioClip audioClip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > minMagnitude)
        {
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }
}
