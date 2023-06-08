using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviourPunCallbacks
{
    public Text ms, nickname, deaths, laps;
    public bool isLobby;

    public GameObject parentPanel;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "LobbyRoom")
        {

            isLobby = true;
            parentPanel = GameObject.Find("PlayersPanel");
        }
        else {
            parentPanel = GameManager.Instance.playersPanel;
            //parentPanel.SetActive(false);
            
        }
    }
    private void Start()
    {
        if (transform.parent == null) {

            
            transform.SetParent(parentPanel.transform);
            if (isLobby)
            {

                transform.localScale = new Vector3(0.430000007f, 0.0799999982f, 0.737063289f);
            }
            else
            {
                transform.localScale = new Vector3(0.970000029f, 0.109124996f, 0.737063289f);
            }
        }

    
    }
    private void Update()
    {
        if (PhotonNetwork.IsConnected && photonView.IsMine)
        {
            if (!isLobby)
            {
                deaths.text = GameManager.Instance.deaths.ToString();
                laps.text = GameManager.Instance.laps.ToString();
            }

            ms.text = PhotonNetwork.GetPing().ToString();
            nickname.text = PhotonNetwork.NickName;
            base.photonView.RPC("RPC_SyncData", RpcTarget.Others, nickname.text, ms.text, deaths.text, laps.text);
        }
    }

    [PunRPC]
    void RPC_SyncData(string nick, string mss, string d, string l) {

        ms.text = mss;
        nickname.text = nick;
        if (!isLobby)
        {
            deaths.text = d;
            laps.text = l;
        }
    
    }
}
