using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using com;

public class VictoryScript : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Text _victoryScore;
    [SerializeField]
    private string _loadlevel = "MainMenu";
    [SerializeField]
    private GameObject _controls;
    [SerializeField]
    private GameObject _victoryPanel;
    private int _score;
    private Scene _currentScene;

    Hashtable hash = iTween.Hash(
       "x", 65,
       "y", 40,
       "time", 2,
       "islocal", true
       );

    private void Start()
    {
        _playButton.onClick.AddListener(Play);
        _currentScene = SceneManager.GetActiveScene();
        _controls.SetActive(true);
        AddListeners();
    }

    private void AddListeners()
    {
        EventManager.AddListener(EventManager.VICTORY, OnVictory);
        EventManager.AddListener(EventManager.DESTROIED, OnDestroied);
        EventManager.AddListener(EventManager.DAMAGED, OnDamage);
        EventManager.AddListener(EventManager.CLICK, OnHome);
    }

    private void Play()
    {
        PlayerPrefs.SetInt(_currentScene.name, _score);
        Debug.Log("Play");
        if (Advertisement.IsReady("rewardedVideo"))
        {
            Advertisement.Show("rewardedVideo");
        }
        SceneManager.LoadScene(_loadlevel);
    }

    private void OnVictory(EventData eventData)
    {
        _controls.SetActive(false);
        iTween.MoveTo(_victoryPanel, hash);
        EventManager.RemoveAllEvents();
    }

    private void OnDamage(EventData eventData)
    {
        _score += Constants.DAMAGE_SCORE;
        _victoryScore.text = "" + _score;
    }

    private void OnDestroied(EventData eventData)
    {
        _score += Constants.DESTROY_SCORE;
        _victoryScore.text = "" + _score;
    }

    private void OnHome(EventData eventData)
    {
        EventManager.RemoveAllEvents();
    }
}