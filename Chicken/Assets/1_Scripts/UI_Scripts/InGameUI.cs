using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviourPunCallbacks
{

    public GameObject settingsPanel, pausePanel;
    public GameObject backToLobby;

    private void Start()
    {
        if (PhotonNetwork.IsConnected && !PhotonNetwork.IsMasterClient)
        {
            backToLobby.SetActive(false);
        }
    }

    private void Update()
    {

   



        if (Input.GetKeyDown(KeyCode.Escape)) {

            pausePanel.SetActive(!pausePanel.activeSelf);
            if (settingsPanel.activeSelf) {

                settingsPanel.SetActive(false);
            }

        }
    }

    public void BackToMenu()
    {


        if (PhotonNetwork.IsConnected)
        {

            PhotonNetwork.LeaveRoom(false);
            PhotonNetwork.LoadLevel("MainMenu");

        }

    }
    public void BackToLobby()
    {


        if (PhotonNetwork.IsConnected)
        {
            base.photonView.RPC("RPC_SendToLobby", RpcTarget.All);
        }

    }

    public void OpenSettingsPanel() {

        settingsPanel.SetActive(true);
    
    }

    [PunRPC]
    public void RPC_SendToLobby() {

        PhotonNetwork.LoadLevel("LobbyRoom");


    }
}
