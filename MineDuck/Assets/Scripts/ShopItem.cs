using com;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    private Button _buyButton;
    [SerializeField]
    private Button _selectButton;
    [SerializeField]
    private Text _duckNameText;
    [SerializeField]
    private string _duckName;
    [SerializeField]
    private Text _duckPriceText;
    [SerializeField]
    private int _duckPrice;
    private bool _isTryingToBuy=false;
    
    private void Awake()
    {
        _duckPriceText.text = "" + _duckPrice;
        _duckNameText.text = _duckName;
    }
    private void Start()
    {
        KeyCheck();
        _buyButton.onClick.AddListener(Buy);
        _selectButton.onClick.AddListener(Select);
        EventManager.AddListener(EventManager.SUCCESS, OnSuccess);
    }

    private void KeyCheck()
    {
        if (PlayerPrefs.HasKey(_duckName))
        {
            _duckPriceText.gameObject.SetActive(false);
            SwitchButtons();
        }
        if (!PlayerPrefs.HasKey("CurrentDuck"))
        {
            PlayerPrefs.SetString("CurrentDuck", "Duck");
        }
    }

    private void SwitchButtons()
    {
        _duckPriceText.gameObject.SetActive(false);
        _buyButton.gameObject.SetActive(false);
        _selectButton.gameObject.SetActive(true);
    }

    private void Buy()
    {
        _isTryingToBuy = true;
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        EventManager.DispatchEvent(EventManager.SPENDCOINS, null);
        Debug.Log("Trying to buy = " + _isTryingToBuy);
    }

    private void OnSuccess(EventData eventData)
    {
        if (_isTryingToBuy)
        {
            Debug.Log("Success");
            PlayerPrefs.SetInt(_duckName, 1);
            SwitchButtons();
            Select();
            _isTryingToBuy = false;
        }
        Debug.Log("Trying to buy = " + _isTryingToBuy);
    }

    private void Select()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        Debug.Log("Current Duck:" + _duckNameText.text);
        DatabaseManager.SetCurrentDuck(_duckNameText.text);
        PlayerPrefs.SetString("CurrentDuck", _duckName);
    }
}