using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerInfoUI : MonoBehaviour
{
    public Text serverName, maxPlayers, region, currentPlayers, maxPlayers2;
    // Start is called before the first frame update
    void Start()
    {
        serverName.text = PhotonNetwork.CurrentRoom.Name.ToString();
        maxPlayers.text = PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
        region.text = PhotonNetwork.CloudRegion.ToString();
        maxPlayers2.text = PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayers.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
    }
}
