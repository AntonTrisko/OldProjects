using UnityEngine;

public class DuckSpawner : MonoBehaviour
{
    private string _duckName;
    [SerializeField]
    private GameObject _parent;

    private void Start()
    {
        _duckName = PlayerPrefs.GetString("CurrentDuck");
        Instantiate(Resources.Load(_duckName) as GameObject, _parent.transform);
    }
}
