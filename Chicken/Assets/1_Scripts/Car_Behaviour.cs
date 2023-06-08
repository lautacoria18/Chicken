using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Car_Behaviour : MonoBehaviour
{
    public Transform startPoint, endPoint;
    public Vector3 startP, alternativeStart;
    public float speed;
    public float speedWheel;
    public bool fromRight;
    public string currentRail;
    public RailBehaviour parentScript;

    public Transform w1, w2, w3, w4;

    void Start()
    {
        startP= transform.localPosition;
        //alternativeStart= transform.localPosition;
        parentScript = GetComponentInParent<RailBehaviour>();
        //fromRight = parentScript.StartFromRight;


        //endPoint = new Vector3(transform.position.x + 10f;
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            if (fromRight)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }

            w1.Rotate(new Vector3(speed * speedWheel * 2, 0, 0) * Time.deltaTime);
            w2.Rotate(new Vector3(speed * speedWheel * 2, 0, 0) * Time.deltaTime);
            w3.Rotate(new Vector3(speed * speedWheel * 2, 0, 0) * Time.deltaTime);
            w4.Rotate(new Vector3(speed * speedWheel * 2, 0, 0) * Time.deltaTime);
        }
        //transform.position = Vector3.Lerp(startPoint.position, endPoint.position, Time.deltaTime * speed);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "restart")
        {
            Respawn();
        }


    }

    public void Respawn() {
        Debug.Log("toca");

        if (Physics.OverlapSphere(startP, 7.0f).Length > 0)
        {
            Debug.Log("ya hay otro auto?");

            //StartCoroutine(WaitForSpawn());
            //Respawn();
            //parentScript.startPoint.position = new Vector3(parentScript.startPoint.position.x -10f, parentScript.startPoint.position.y, parentScript.startPoint.position.z);
            transform.localPosition = alternativeStart;
            Debug.Log(transform.localPosition);
           
        }
        else
        {
            transform.localPosition = startP;
        }
        int random = Random.Range(14, 25);
        speed = random;

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "car")
        {
            if (transform.localPosition.x > other.gameObject.transform.localPosition.x) {

                speed += 0.3f;
            
            }
            Debug.Log("toca otro auto");
        }
    }

    public void ONTRI(Collision collision) {

     
    }
    IEnumerator WaitForSpawn() { 
    
        yield return new WaitForSeconds(2f);
        //transform.localPosition = startP;
    }

}
