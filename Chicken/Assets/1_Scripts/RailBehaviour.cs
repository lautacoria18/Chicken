using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RailBehaviour : MonoBehaviourPunCallbacks
{
    public GameObject[] childrens;
    public string rail;
    public bool wait;

    public Transform startPoint;

    private void Awake()
    {
        startPoint = transform;
    }
    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            if (PhotonNetwork.IsMasterClient) {

                StartCoroutine(SpawnCar_Online());

            }
         

        }

        
        else
        {
            StartCoroutine(SpawnCar());
        }
    }

 

    private IEnumerator SpawnCar_Online()
    {

        int randomNum = Random.Range(0, childrens.Length);


        //chequear si estan todos prendidos


        ////
        ///
        if (!childrens[randomNum].gameObject.activeSelf)
        {
            base.photonView.RPC("RPC_Spawn", RpcTarget.All, randomNum);
            yield return new WaitForSeconds(3);
            StartCoroutine(SpawnCar_Online());
        }

        else
        {
            if (CheckForChildrens())
            {
                Debug.Log("over");

            }
            else { StartCoroutine(SpawnCar_Online()); }

        }


    }

    [PunRPC]
    public void RPC_Spawn(int randomNum)
    {
        childrens[randomNum].gameObject.SetActive(true);

    }


    private IEnumerator SpawnCar()
    {

        int randomNum = Random.Range(0, childrens.Length);


        //chequear si estan todos prendidos


        ////
        ///
        if (!childrens[randomNum].gameObject.activeSelf)
        {
            childrens[randomNum].gameObject.SetActive(true);
            yield return new WaitForSeconds(3);
            StartCoroutine(SpawnCar());
        }

        else
        {
            if (CheckForChildrens())
            {
                Debug.Log("over");

            }
            else { StartCoroutine(SpawnCar()); }

        }


    }

    private bool CheckForChildrens()
    {

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (!gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
}
