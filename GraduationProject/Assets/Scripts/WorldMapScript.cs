using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldMapScript : MonoBehaviour
{
    [SerializeField]
    private Button _levelButton;

    void Start()
    {
        _levelButton.onClick.AddListener(Load);
    }

    private void Load()
    {
        AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        SceneManager.LoadScene(_levelButton.gameObject.name);
    }
}