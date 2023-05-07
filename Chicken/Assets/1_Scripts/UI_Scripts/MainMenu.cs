using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public GameObject multiplayerPanel;
    public GameObject mainButtons;


    public void MultiplayerPanel() {

        multiplayerPanel.SetActive(!multiplayerPanel.activeSelf);
        mainButtons.SetActive(!mainButtons.activeSelf);

    }
}
