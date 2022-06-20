using UnityEngine;
using UnityEngine.UI;

public class StarsScript : MonoBehaviour
{
    private Image _im;
    [SerializeField]
    private Sprite _star1;
    [SerializeField]
    private Sprite _star2;
    [SerializeField]
    private Sprite _star3;
    [SerializeField]
    private Records _records;
    private int _score;

    void Start()
    {
        _score = PlayerPrefs.GetInt(gameObject.name);
        _im = gameObject.GetComponent<Image>();
        if (_score >= _records.goal)
        {
            _im.sprite = _star3;
        }
        if (_score >= _records.goal/2 && _records.score < _records.goal)
        {
            _im.sprite = _star2;
        }
        if (_score >= _records.goal / 3 && _records.score < _records.goal/2)
        {
            _im.sprite = _star1;
        }
    }
}