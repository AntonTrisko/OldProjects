using com;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverPanel;
    [SerializeField]
    private Button _retryButton;
    Hashtable hash = iTween.Hash(
       "x", 65,
       "y", 40,
       "time", 2,
       "islocal", true
       );

    void Start()
    {
        _retryButton.onClick.AddListener(Retry);
        EventManager.AddListener(EventManager.GAMEOVER, OnGameOver);
    }

    private void Retry()
    {
        var scene = SceneManager.GetActiveScene();
        EventManager.RemoveAllEvents();
        SceneManager.LoadScene(scene.name);
    }

    private void OnGameOver(EventData eventData)
    {
        iTween.MoveTo(_gameOverPanel, hash);
    }
}
