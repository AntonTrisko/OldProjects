using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static float _points;

    private bool _isPressed;
    [SerializeField]
    private Slider _forceSlider;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
        StartCoroutine(AddPoints());
        Debug.Log(_points);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }

    IEnumerator AddPoints()
    {
        while (_isPressed == true)
        {
            AudioManager.SingletonInstance.PlaySound(AudioName.BallistaPull);
            _points = Mathf.Clamp(_points + 0.2f, 1.5f, 2.5f);
            _forceSlider.value = _points;
            yield return new WaitForSeconds(1);
        }
    }
}