using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _time = 3;
    private Vector3 _velocity;
    private Vector3 _targetVector;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _targetVector = new Vector3(_target.position.x, _target.position.y + 30f, _target.position.z - 10f);
        gameObject.transform.position = Vector3.SmoothDamp(gameObject.transform.position, _targetVector, ref _velocity, _time);
    }
}