using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using com;

public class LevelUIControl : MonoBehaviour
{
    [SerializeField]
    private Button _homeButton;
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _arrowsText;
    private int _score;
    private int _arrowsLeft;
    [SerializeField]
    private int _targetScore;
    [SerializeField]
    private Records _records;

    void Start()
    {
        _score = 0;
        _arrowsLeft = _records.arrows;
        _records.goal = _targetScore;
        _arrowsText.text = "Arrows:" + _arrowsLeft;
        AddListeners();
    }

    private void AddListeners()
    {
        _homeButton.onClick.AddListener(Home);
        EventManager.AddListener(EventManager.DESTROIED, OnDestroied);
        EventManager.AddListener(EventManager.DAMAGED, OnDamage);
        EventManager.AddListener(EventManager.FIRED, OnFired);
    }

    private void Home()
    {
        EventManager.DispatchEvent(EventManager.CLICK, null);
        EventManager.RemoveAllEvents();
        SceneManager.LoadScene("MainMenu");
    }
 
    private void OnDamage(EventData eventData)
    {
        _score += Constants.DAMAGE_SCORE;
        _records.score = _score;
        _scoreText.text = "Score: " + _score;
        Debug.Log(_score);
        if (_targetScore <= _score)
        {
            EventManager.DispatchEvent(EventManager.VICTORY, null);
            _homeButton.onClick.RemoveListener(Home);
            EventManager.RemoveEvent(EventManager.DESTROIED, OnDestroied);
            EventManager.RemoveEvent(EventManager.DAMAGED, OnDamage);
        }
    }

    private void OnFired(EventData eventData)
    {
        _arrowsLeft--;
        _arrowsText.text = "Arrows:" + _arrowsLeft;
        if (_arrowsLeft == 0)
        {
            Debug.Log("Game over!");
            EventManager.DispatchEvent(EventManager.GAMEOVER, null);
        }
    }

    private void OnDestroied(EventData eventData)
    {
        _score += Constants.DESTROY_SCORE;
        _records.score = _score;
        _scoreText.text = "Score: " + _score;
    }
}