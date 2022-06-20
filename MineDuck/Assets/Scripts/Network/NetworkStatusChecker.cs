using UnityEngine;
using UnityEngine.UI;

public class NetworkStatusChecker : MonoBehaviour
{
    [SerializeField]
    private GameObject _internetFailurePanel;
    [SerializeField]
    private Button _tryAgainButton;
    private bool _hasInternet;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    void Start()
    {
        InvokeRepeating("CheckInternetConnection", 1f, 30f);
    }

    private void CheckInternetConnection()
    {
        _hasInternet = DatabaseManager.HasInternetConnection();
        if (!_hasInternet)
        {
            _tryAgainButton.onClick.AddListener(TryAgain);
            _internetFailurePanel.SetActive(true);
        }
    }

    private void TryAgain()
    {
        _hasInternet = DatabaseManager.HasInternetConnection();
        if (_hasInternet)
        {
            _internetFailurePanel.SetActive(false);
        }
    }
}