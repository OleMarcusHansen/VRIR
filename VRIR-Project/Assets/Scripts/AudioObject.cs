using UnityEngine;

public class AudioObject : MonoBehaviour
{
    [SerializeField] float minMagnitude = 1;
    [SerializeField] AudioClip audioCollision;

    public AudioClip audioPickup;

    private void OnCollisionEnter(Collision collision)
    {
        if (audioCollision != null && collision.relativeVelocity.magnitude > minMagnitude)
        {
            AudioSource.PlayClipAtPoint(audioCollision, transform.position);
        }
    }
}
