using UnityEngine;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _tutorialPanel;
    [SerializeField]
    private Button _okButton;
    [SerializeField]
    private Toggle _showToggle;
    private string _hide = "Hide";

    void Start()
    {
        HasKey();
        ShowPrefs();
        _showToggle.onValueChanged.AddListener(delegate { ToggleStatus(); });
    }

    private void HasKey()
    {
        if (!PlayerPrefs.HasKey(_hide))
        {
            PlayerPrefs.SetInt(_hide, 0);
        }
    }

    private void ShowPrefs()
    {
        if (PlayerPrefs.GetInt(_hide) == 0)
        {
            _tutorialPanel.SetActive(true);
            _okButton.onClick.AddListener(CloseTutorial);
            _showToggle.isOn = false;
        }
        else if (PlayerPrefs.GetInt(_hide) == 1)
        {
            _showToggle.isOn = true;
        }
    }

    private void ToggleStatus()
    {
        if (_showToggle.isOn)
        {
            Debug.Log("Hide");
            PlayerPrefs.SetInt(_hide, 1);
        }
        else 
        {
            PlayerPrefs.SetInt(_hide, 0);
        }
    }

    private void CloseTutorial()
    {
        _tutorialPanel.SetActive(false);
    }
}