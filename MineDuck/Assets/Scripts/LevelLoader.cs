using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private Button _loadLevel;
    [SerializeField]
    private Animator _loadingAnimator;
    [SerializeField]
    private GameObject _crossfadeGameObject;
    [SerializeField]
    private float _loadAnimationTime = 1f;

    private void Start()
    {
        _loadLevel.onClick.AddListener(LoadLevel);
        _loadingAnimator.Play("CrossfadeEnd");
    }

    private void LoadLevel()
    {
        StartCoroutine(Loading(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator Loading(int levelIndex)
    {
        Debug.Log("Play");
         AudioManager.SingletonInstance.PlaySound(AudioName.ButtonClick);
        _loadingAnimator.Play("CrossfadeStart");
        yield return new WaitForSeconds(_loadAnimationTime);
        SceneManager.LoadScene(levelIndex);
    }
}