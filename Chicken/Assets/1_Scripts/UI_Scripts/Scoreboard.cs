using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scoreboard : MonoBehaviourPunCallbacks
{
    public GameObject PlayersPanel;

    private void Awake()
    {
        GameObject child;
        if (SceneManager.GetActiveScene().name == "LobbyRoom")
        {

            child = PhotonNetwork.Instantiate("LobbyPlayerInfo", new Vector3(0f, 0f, 0f), Quaternion.identity);

        }
        else
        {
            child = PhotonNetwork.Instantiate("PlayerUIPanel", new Vector3(0f, 0f, 0f), Quaternion.identity);

        }
        child.transform.SetParent(PlayersPanel.transform);
        child.transform.localScale = new Vector3(0.970000029f, 0.109124996f, 0.737063289f);
    }


}
