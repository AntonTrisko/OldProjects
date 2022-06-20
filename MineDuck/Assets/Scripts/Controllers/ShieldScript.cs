using UnityEngine;

public class ShieldScript : Collectible
{
    private void OnCollisionEnter(Collision collision)
    {
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
