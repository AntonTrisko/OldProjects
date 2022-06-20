using com;
using UnityEngine;

public class MineScript : Collectible
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("YOU DIED");
        Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Player")
        {
            ShowExplosion();
            OnDeath();
            HideObject();
        }
        if (collision.collider.tag == "Shield")
        {
            ShowExplosion();
            HideObject();
        }
    }

    private void ShowExplosion()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.Explosion);
        ParticleManager.Instance.PlayExplosionParticle(gameObject.transform.position);
    }

    private void OnDeath()
    {
        EventManager.DispatchEvent(EventManager.GAMEOVER, null);
    }

    private void OnBecameInvisible()
    {
        HideObject();
    }

    public override void HideObject()
    {
        gameObject.SetActive(false);
    }
}