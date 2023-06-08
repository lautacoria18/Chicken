using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        
        StartCoroutine(WaitAndConnect());
       
    }


    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator WaitAndConnect() {


        yield return new WaitForSeconds(2f);
        PhotonNetwork.ConnectUsingSettings();
    }

}
