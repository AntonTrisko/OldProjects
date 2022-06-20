using InControl;
using UnityEngine;

public class DuckController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _duckRigidbody;
    [SerializeField]
    private float _speedMultiplier;
    private float _xSpeed;
    private float _ySpeed;
    private float _rotation;
    private Quaternion _duckQuaternion;

    private void FixedUpdate()
    {
        var inputDevice = InputManager.ActiveDevice;
        if (inputDevice.LeftStick.IsPressed)
        {
            _xSpeed = inputDevice.Direction.X * _speedMultiplier;
            _ySpeed = inputDevice.Direction.Y * _speedMultiplier;
            _rotation = inputDevice.Direction.X * 50 * Time.deltaTime;
        }
        MoveDuck();
        RotateDuck();
    }

    private void MoveDuck()
    {
        _duckRigidbody.AddForce(new Vector3(_xSpeed, 0, _ySpeed), ForceMode.Impulse);
        _xSpeed *= 0.96f;
        _ySpeed *= 0.96f;
    }
    private void RotateDuck()
    {
        _duckQuaternion = Quaternion.Euler(0, _rotation, 0);
        _duckRigidbody.MoveRotation(_duckRigidbody.rotation * _duckQuaternion);
    }
}