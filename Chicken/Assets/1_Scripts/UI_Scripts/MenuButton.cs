using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Text theText;
    private AudioClip theClip;
    private AudioSource audioSrc;

    private Color firstColor;

    private void Awake()
    {
        
        theClip = (AudioClip)Resources.Load("Tick");
        audioSrc = gameObject.AddComponent<AudioSource>();
        audioSrc.clip = theClip;
        theText = GetComponentInChildren<Text>();
        firstColor = theText.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSrc.Play();
        theText.color = Color.red; //Or however you do your color
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        theText.color = firstColor; //Or however you do your color
    }

    public void OpenLink(string link) {


        Application.OpenURL(link);

    }
}
