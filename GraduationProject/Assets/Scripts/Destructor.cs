using com;
using System.Collections.Generic;
using UnityEngine;

public class Destructor : MonoBehaviour
{
    public static bool isDamaged;
    public static bool isDestroyed;
   

    [SerializeField]
    private List<string> _destructorList;
    [SerializeField]
    private int _lifes;
    [SerializeField]
    private ParticleSystem _debris;
    private Rigidbody2D _rig;
    private int _damages;
    private Transform _debrisTransform;

    private void Awake()
    {
        _debrisTransform = _debris.transform;
        _rig = GetComponent<Rigidbody2D>();
        isDamaged = false;
        isDestroyed = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 0; i < _destructorList.Count; i++)
        {
            if (collision.collider.CompareTag(_destructorList[i]))
            {
                AudioManager.SingletonInstance.PlaySound(AudioName.HitSound);
                _debrisTransform.position = gameObject.transform.position + new Vector3(-0.5f,0,0);
                _debris.Play();
                isDamaged = true;
                _lifes--;
                _damages ++; 
                Debug.Log("Damages: " + _damages);
                EventManager.DispatchEvent(EventManager.DAMAGED, null);
                Debug.Log("Damaged!");
            }
            if (_damages == 2)
            {
                isDestroyed = true;
            }
            if (_lifes == 0)
            {
                _debrisTransform.position = gameObject.transform.position + new Vector3(-0.5f, 0, 0);
                _debris.Play();
                Destroy(this.gameObject);
                EventManager.DispatchEvent(EventManager.DESTROIED, null);
                Debug.Log("Lifes Out!");
            }
          
        }
    }

    private void Start()
    {
        if (InstantiatePrefab.isDynamic && _rig != null)
        {
            _rig.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}