using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : MonoBehaviourPunCallbacks
{

    public Text [] playerListText;

    public GameObject PlayersPanel;

    private void Awake()
    {
        GameObject child = PhotonNetwork.Instantiate("LobbyPlayerInfo", new Vector3(0f, 0f, 0f), Quaternion.identity);
        child.transform.SetParent(PlayersPanel.transform);
        child.transform.localScale = new Vector3(0.430000007f, 0.0799999982f, 0.737063289f);
    }

    void Start()
    {
        
        /*
        Debug.Log(PhotonNetwork.NickName);
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        Debug.Log(PhotonNetwork.CurrentRoom.MaxPlayers);

        Debug.Log(PhotonNetwork.CountOfPlayersInRooms);
        if (PhotonNetwork.IsMasterClient)
        {

            playerListText[0].text = PhotonNetwork.NickName;
        }
        else {

            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {

                playerListText[i].text = PhotonNetwork.PlayerList[i].NickName;

            }


        }
        */
    }


    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("cambiio");

    }
    /*
        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                playerListText[i].text = PhotonNetwork.PlayerList[i].NickName;

            }

        }

        */
    public void BackToMenu() {

        PhotonNetwork.LeaveRoom(false);
        PhotonNetwork.LoadLevel("MainMenu");
    
    }
    public void StartGame()
    {

        base.photonView.RPC("RPC_StartGame", RpcTarget.All);

    }
    [PunRPC]
    public void RPC_StartGame() {

        PhotonNetwork.LoadLevel("SampleScene");

    }
    void Update()
    {

      //hacer un rcp mandando el id y el ping
    }
}
