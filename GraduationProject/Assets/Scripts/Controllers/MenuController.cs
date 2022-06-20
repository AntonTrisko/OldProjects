using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button _settingsButton;
    [SerializeField]
    private Button _acceptSettingsButton;
    [SerializeField]
    private GameObject _settingsPanel;
    [SerializeField]
    private Button _exitButton;
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _achievmentButton;

    #region hashtables
    Hashtable settingsHash = iTween.Hash(
        "x",40,
        "y",40,
        "time",2,
        "islocal",true
        );
    Hashtable hideSettingsHash = iTween.Hash(
        "x", 40,
        "y", 1200,
        "time", 2,
        "islocal", true
        );
    Hashtable sideHash = iTween.Hash(
       "x", -600,
       "y", 130,
       "time", 2,
       "islocal", true
       );
    Hashtable hideSideHash = iTween.Hash(
        "x", -1500,
        "y", 130,
        "time", 2,
        "islocal", true
        );
    #endregion

    void Start()
    {
        AudioManager.SingletonInstance.PlayMusic(MusicName.MenuMusic);
        _settingsButton.onClick.AddListener(ShowSettings);
        _acceptSettingsButton.onClick.AddListener(HideSettingsPanel);
        _exitButton.onClick.AddListener(Exit);
        _playButton.onClick.AddListener(Play);
        _achievmentButton.onClick.AddListener(Achievment);
    }

    private void ShowSettings()
    {
        iTween.MoveTo(_settingsPanel, settingsHash);
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
    }

    private void HideSettingsPanel()
    {
        iTween.MoveTo(_settingsPanel, hideSettingsHash);
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
    }

    private void Exit()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        Application.Quit();
    }

    private void Play()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        Debug.Log("Play");
        SceneManager.LoadScene("WorldMap");
    }

    private void Achievment()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        Debug.Log("Achievment");
    }
}