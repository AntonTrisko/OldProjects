using com;
using UnityEngine;

public class SmashScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rig;
    [SerializeField]
    private ParticleSystem _debris;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.attachedRigidbody != null && 
            collision.collider.attachedRigidbody.mass > (2 * _rig.mass))
        {
            Debug.Log("Smashed!");
            _debris.transform.position = this.gameObject.transform.position + new Vector3(-0.5f, 0, 0);
            _debris.Play();
            EventManager.DispatchEvent(EventManager.DESTROIED, null);
            Destroy(this.gameObject);
        }
    }
}