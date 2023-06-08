using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerInfoUI : MonoBehaviourPunCallbacks
{
    public Text serverName, maxPlayers, region, currentPlayers, maxPlayers2;

    public GameObject lapsText;
    public Dropdown laps;
    public GameObject buttonStart;
    // Start is called before the first frame update
    void Start()
    {
        if (!PhotonNetwork.IsMasterClient) {
            lapsText.SetActive(true);
            laps.gameObject.SetActive(false);
            buttonStart.SetActive(false);
        }
        

        serverName.text = PhotonNetwork.CurrentRoom.Name.ToString();
        maxPlayers.text = PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
        region.text = PhotonNetwork.CloudRegion.ToString();
        maxPlayers2.text = PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
        if (PhotonNetwork.IsMasterClient)
        {
            GameConstants.Instance.laps = int.Parse(laps.captionText.text);
            //int.Parse(cantPlayersDropdown.captionText.text);
            base.photonView.RPC("RPC_SetLaps", RpcTarget.Others, int.Parse(laps.captionText.text));
        }
     
    }

    [PunRPC]
    public void RPC_SetLaps(int lapsValue) {

        lapsText.GetComponent<Text>().text = lapsValue.ToString();
        GameConstants.Instance.laps = lapsValue;


    }
    
}
