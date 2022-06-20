using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchTrack : MonoBehaviour
{
   private void Awake()
    {
        Scene _currentScene = SceneManager.GetActiveScene();
        Debug.Log(_currentScene.name);
        if (_currentScene.name == "MainMenu")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.MenuMusic);
        }
        if (_currentScene.name == "WorldMap")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.WorldMapMusic);
        }
        if (_currentScene.name == "Level1")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.GrassLandMusic);
        }
        if (_currentScene.name == "Level2")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.CavernMusic);
        }
        if (_currentScene.name == "Level3")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.ForestMusic);
        }
        if (_currentScene.name == "Level4")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.GrassLandMusic);
        }
        if (_currentScene.name == "Level5")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.ForestMusic);
        }
        if (_currentScene.name == "Level6")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.CavernMusic);
        }
        if (_currentScene.name == "Level7")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.GrassLandMusic);
        }
        if (_currentScene.name == "Level8")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.MenuMusic);
        }
        if (_currentScene.name == "Level9")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.CavernMusic);
        }
        if (_currentScene.name == "Level10")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.GrassLandMusic);
        }
        if (_currentScene.name == "Level11")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.VulcanicMusic);
        }
        if (_currentScene.name == "Level12")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.VulcanicMusic);
        }
        if (_currentScene.name == "Level13")
        {
            AudioManager.SingletonInstance.PlayMusic(MusicName.VulcanicMusic);
        }
    }

}
