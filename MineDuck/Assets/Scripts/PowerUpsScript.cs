using UnityEngine;

public class PowerUpsScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _shield;
    [SerializeField]
    private Collider _duckCollider;
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.tag == "Shield")
        {
            _shield.SetActive(true);
        }
        
        if (collision.collider.tag == "Shootable")
        {
            _shield.SetActive(false);
        }
    }
}