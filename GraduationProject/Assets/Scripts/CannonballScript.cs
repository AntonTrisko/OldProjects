using UnityEngine;

public class CannonballScript : MonoBehaviour
{
   
    [SerializeField]
    private Rigidbody2D _rig;
    [SerializeField]
    private TrailRenderer _tr;
    private float _degree = Mathf.PI / 180;
   
   private void OnEnable()
    {
        _rig.AddForce(TimerScript._points * new Vector2(Constants.FORCE * Mathf.Cos(_degree * InstantiatePrefab.cannonRotation),
        Constants.FORCE * Mathf.Sin(_degree * InstantiatePrefab.cannonRotation)));
        Debug.Log(InstantiatePrefab.cannonRotation);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        _rig.bodyType = RigidbodyType2D.Dynamic;
        TimerScript._points = 1.5f;
        if (!collision.collider.gameObject.CompareTag(Constants.TAG_PLAYER))
        {
            this.gameObject.SetActive(false);
            _tr.Clear();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _rig.AddForce(new Vector3(-300, 0, 0));
    }
}