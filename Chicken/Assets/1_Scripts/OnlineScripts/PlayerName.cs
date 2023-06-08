using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerName : MonoBehaviourPunCallbacks
{
    public TextMeshPro textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {

            textMeshProUGUI.enabled = false;
        }
        else
        {
            textMeshProUGUI.text = photonView.Owner.NickName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
