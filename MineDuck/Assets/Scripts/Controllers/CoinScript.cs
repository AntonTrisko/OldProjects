using com;
using UnityEngine;

public class CoinScript : Collectible
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Coin!");
        AudioManager.SingletonInstance.PlaySound(AudioName.Coin);
        EventManager.DispatchEvent(EventManager.ADDCOIN, null);
        HideObject();
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