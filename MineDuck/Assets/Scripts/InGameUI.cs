using com;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private Button _retryButton;
    [SerializeField]
    private Button _homeButton;
    [SerializeField]
    private Text _coinText;
    [SerializeField]
    private Text _endScore;
    private int _coins;

    Hashtable hash = iTween.Hash(
       "x", 0,
       "y", 0,
       "time", 2,
       "islocal", true
       );

    private void Start()
    {
        _homeButton.onClick.AddListener(Home);
        _retryButton.onClick.AddListener(RetryLevel);
        EventManager.AddListener(EventManager.GAMEOVER, OnGameOver);
        EventManager.AddListener(EventManager.ADDCOIN, OnAddCoin);
        _coinText.text = "" + _coins;
    }

    private void Home()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        SceneManager.LoadScene("MainMenu");
    }
    private void RetryLevel()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        SceneManager.LoadScene("Level");
    }

    private void OnGameOver(EventData eventData)
    {
        _endScore.text = _coinText.text;
        iTween.MoveTo(_gameOverPanel, hash);
        EventManager.RemoveAllEvents();
    }

    private void OnAddCoin(EventData eventData)
    {
        _coins++;
        _coinText.text = "" + _coins;
    }
}