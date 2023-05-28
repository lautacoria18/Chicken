using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    public CinemachineFreeLook cine;
    public GameObject playerOffline;
    // Start is called before the first frame update
    void Awake()
    {
        if (PhotonNetwork.IsConnected)
        {
            int randomX = Random.Range(-7, 7);
            GameObject obj = PhotonNetwork.Instantiate("ThirdPersonPlayer", new Vector3(randomX, 1.0051f, -9.6113f), Quaternion.identity);
            cine.Follow = obj.transform;
            cine.LookAt = obj.transform;
            obj.GetComponent<PlayerMoveNew>().cam = GameObject.Find("MainCamera").transform;
        }
        else {
            int randomX = Random.Range(-7, 7);
            GameObject obj = Instantiate(playerOffline, new Vector3(randomX, 1.0051f, -9.6113f), Quaternion.identity);
            cine.Follow = obj.transform;
            cine.LookAt = obj.transform;
            obj.GetComponent<PlayerMoveNew>().cam = GameObject.Find("MainCamera").transform;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
