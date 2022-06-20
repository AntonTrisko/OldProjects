using UnityEngine;

public class Arrow : MonoBehaviour
{

    [SerializeField]
    private Rigidbody2D _arrowRigidbody;
    [SerializeField]
    private TrailRenderer _arrowTrail;
    private float _degree = Mathf.PI / 180;

    private void OnEnable()
    {
        Debug.Log(SwipeControl.rotation);
        _arrowRigidbody.AddForce(TimerScript._points *
        new Vector2(Constants.FORCE * Mathf.Cos(_degree * SwipeControl.rotation),
        Constants.FORCE * Mathf.Sin(_degree * SwipeControl.rotation)));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.collider.tag);
        _arrowRigidbody.bodyType = RigidbodyType2D.Dynamic;
        TimerScript._points = 1.5f;
        if (!collision.collider.gameObject.CompareTag(Constants.TAG_PLAYER))
        {
            this.gameObject.SetActive(false);
            _arrowTrail.Clear();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("WindTrigger");
        _arrowRigidbody.AddForce(new Vector3(-300, 0, 0));
    }
}
