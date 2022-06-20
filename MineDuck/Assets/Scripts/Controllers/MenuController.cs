using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using com;

public class MenuController : MonoBehaviour
{
    #region UIElements
    [SerializeField]
    private Button _settingsButton;
    [SerializeField]
    private Button _acceptSettingsButton;
    [SerializeField]
    private GameObject _settingsPanel;
    [SerializeField]
    private Button _exitButton;
    [SerializeField]
    private Button _shopButton;
    [SerializeField]
    private Button _closeShopButton;
    [SerializeField]
    private Button _getCoinsButton;
    [SerializeField]
    private Text _coinsText;
    [SerializeField]
    private Text _diamondsText;
    [SerializeField]
    private GameObject _shopPanel;
    private int _coins;
    #endregion
    #region hashtables
    Hashtable settingsHash = iTween.Hash(
        "x", 40,
        "y", 0,
        "time", 2,
        "islocal", true
        );
    Hashtable hideSettingsHash = iTween.Hash(
        "x", 40,
        "y", 4500,
        "time", 2,
        "islocal", true
        );
    #endregion

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    void Awake()
    {
        SetRecourcesText();
        AudioManager.SingletonInstance.PlayMusic(MusicName.MenuMusic);
        AddListeners();
    }

    private void SetRecourcesText()
    {
        DatabaseManager.GetUser(Constants.NICKNAME, user =>
        {
            _coinsText.text = "" + user.coins;
            _diamondsText.text = "" + user.diamonds;
        }
        );
    }
    
    private void AddListeners()
    {
        EventManager.AddListener(EventManager.SUCCESS, UpdateValues);
        _settingsButton.onClick.AddListener(ShowSettings);
        _acceptSettingsButton.onClick.AddListener(HideSettingsPanel);
        _exitButton.onClick.AddListener(Exit);
        _shopButton.onClick.AddListener(OpenShop);
        _closeShopButton.onClick.AddListener(CloseShop);
        _getCoinsButton.onClick.AddListener(GetCoinsForAds);
    }

    private void UpdateValues(EventData eventData)
    {
        Debug.Log("Updated");
        SetRecourcesText();
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

    private void OpenShop()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        iTween.MoveTo(_shopPanel, settingsHash);
        Debug.Log("Shop");
    }

    private void CloseShop()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        iTween.MoveTo(_shopPanel, hideSettingsHash);
    }

    private void GetCoinsForAds()
    {
        if (Advertisement.IsReady("GetCoins"))
        {
            EventManager.DispatchEvent(EventManager.ADVERTISMENT, null);
            SetRecourcesText();
            Advertisement.Show("GetCoins");
        }
    }
}