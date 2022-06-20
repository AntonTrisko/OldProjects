using UnityEngine.UI;
using UnityEngine;

public class LogInScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _logInPanel;
    [SerializeField]
    private InputField _nickInput;
    [SerializeField]
    private Button _submitButton;
    private User _user = new User(null,"Duck",0,0,0);

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private void Init()
    {
        if (!PlayerPrefs.HasKey("NickName") || !PlayerPrefs.HasKey("Id"))
        {
            _logInPanel.SetActive(true);
            _submitButton.onClick.AddListener(OnSubmit);
        }
    }

    private void OnSubmit()
    {
        SetUserInfo();
        DatabaseManager.PostUserToDatabase (_user);
        _logInPanel.SetActive(false);
    }

    private void SetUserInfo()
    {
        PlayerPrefs.SetString("NickName", _nickInput.text);
        _user.nickname = PlayerPrefs.GetString("NickName");
        _user._id = Random.Range(0, 999);
        PlayerPrefs.SetInt("Id", _user._id);
    }
}