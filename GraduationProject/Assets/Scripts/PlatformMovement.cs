using System.Collections;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 _destination;
    [SerializeField]
    private float _time;
    [SerializeField]
    private iTween.EaseType _easeType;

    void Start()
    {
        Hashtable hashtable = iTween.Hash(
            "x", _destination.x,
            "y", _destination.y,
            "islocal", true,
            "time", _time,
            "EaseType", _easeType,
           "looptype", "pingPong"
            );
        iTween.MoveTo(gameObject, hashtable);
    }
}