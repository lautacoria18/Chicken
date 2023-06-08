using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    public Slider volumeSlider;
    public Toggle soundsToggle;
    public AudioSource gameAudio;
    public GameConstants gameConstants;
    public GameObject mainButtons;

    public bool isGameScene;
    private void Awake()
    {
        volumeSlider.value= gameAudio.volume;
    }


    private void Update()
    {
        
        gameAudio.volume= volumeSlider.value;
        GameConstants.Instance.globalVolume= volumeSlider.value;
    }

    public void Back() {
       
            mainButtons.SetActive(true);
        
        gameObject.SetActive(false);


    }
}
