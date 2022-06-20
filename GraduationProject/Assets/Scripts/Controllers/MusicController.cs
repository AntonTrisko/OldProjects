using UnityEngine;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    private Toggle _muteToggle;
    [SerializeField]
    private Slider _musicSlider;
    [SerializeField]
    private Slider _soundSlider;
    [SerializeField]
    private Slider _masterSlider;
    private float _muteVol =-80f;
    private string _mute = "Mute";
    private string _masterVol = "MasterVolume";
    private string _musicVol = "MusicVolume";
    private string _soundVol = "SoundVolume";

    void Start()
    {
        HasKey();
        _masterSlider.value = PlayerPrefs.GetFloat(_masterVol);
        _musicSlider.value = PlayerPrefs.GetFloat(_musicVol);
        _soundSlider.value = PlayerPrefs.GetFloat(_soundVol);
        Volume();
        _muteToggle.onValueChanged.AddListener(delegate { MuteStatus(); });
        _masterSlider.onValueChanged.AddListener(delegate { Volume(); });
        _musicSlider.onValueChanged.AddListener(delegate { Volume(); });
        _soundSlider.onValueChanged.AddListener(delegate { Volume(); });
        MuteStatus();
    }
    private void HasKey()
    {
        if (!PlayerPrefs.HasKey(_mute))
        {
            PlayerPrefs.SetInt(_mute, 0);

        }
        if (PlayerPrefs.GetInt(_mute) == 1)
        {
            _muteToggle.isOn = true;
        }
        if (!PlayerPrefs.HasKey(_musicVol))
        {
            PlayerPrefs.SetFloat(_musicVol, 3);
        }
        if (!PlayerPrefs.HasKey(_soundVol))
        {
            PlayerPrefs.SetFloat(_soundVol, 3);
        }
        if (!PlayerPrefs.HasKey(_masterVol))
        {
            PlayerPrefs.SetFloat(_masterVol, 3);
        }
    }
    private void MuteStatus()
    {
        if (_muteToggle.isOn)
        {
            Debug.Log("Mute");
            PlayerPrefs.SetInt(_mute, 1);
            AudioManager.SingletonInstance.SetMixerValue(_masterVol, -80f);
        }
        else
        {
            Debug.Log("Unmute");
            PlayerPrefs.SetInt(_mute, 0);
            AudioManager.SingletonInstance.SetMixerValue(_masterVol, _masterSlider.value);
        }
    }

    private void Volume()
    {
        AudioManager.SingletonInstance.SetMixerValue(_masterVol, _masterSlider.value);
        AudioManager.SingletonInstance.SetMixerValue(_musicVol, _musicSlider.value);
        AudioManager.SingletonInstance.SetMixerValue(_soundVol, _soundSlider.value);
        PlayerPrefs.SetFloat(_masterVol, _masterSlider.value);
        PlayerPrefs.SetFloat(_musicVol, _musicSlider.value);
        PlayerPrefs.SetFloat(_soundVol, _soundSlider.value);
    }
}