using UnityEngine;

public class ChageSprite : MonoBehaviour
{
    [SerializeField]
    private Sprite _damagedSprite1;
    [SerializeField]
    private Sprite _damagedSprite2;
    private SpriteRenderer _rndr;

    void Start()
    {
        _rndr = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Destructor.isDamaged)
        {
            Debug.Log("Sprite1");
            _rndr.sprite = _damagedSprite1;
        }
        if (Destructor.isDestroyed)
        {
            Debug.Log("Sprite2");
            _rndr.sprite = _damagedSprite2;
        }
    }
}