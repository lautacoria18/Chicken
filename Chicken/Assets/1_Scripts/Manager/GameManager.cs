using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public int lapsToWin;
    public static GameManager Instance;

    public GameObject winnerPanel;
    public GameObject textWinnerPanel;


    public GameObject scoreboard, playersPanel;

    public int laps, deaths;

    public bool canPlay;
    void Awake()
    {
      
            Instance = this;
       
        lapsToWin = GameConstants.Instance.laps;
    }
    private void Update()
    {

        if (Input.GetKey(KeyCode.Tab))
        {

            scoreboard.transform.localPosition = new Vector3(0, 0, 0);
        }
        else
        {
            scoreboard.transform.localPosition = new Vector3(0, -1889f, 0);

        }

    }

    public void SetDeathsAndLaps(int d, int l) {
    
        deaths = d;
        laps = l;
        
    }
    public void OpenWinnerPanel() {

        if (PhotonNetwork.IsConnected) {

            string nickname = PhotonNetwork.NickName;
            base.photonView.RPC("RPC_ShowWinnerPanel", RpcTarget.All, nickname);

            //haces una rpc call
        }
        //abre el panel

    }

    [PunRPC]
    void RPC_ShowWinnerPanel(string nickname) {
        textWinnerPanel.GetComponent<Text>().text = "Player " + nickname + " wins";
        winnerPanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Gano el " + nickname);
        GetComponent<AudioSource>().Play();
        
    }
    ///hacer funcion para mostrar en pantalla al ganador
}
