using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMoveNew : MonoBehaviourPunCallbacks
{
    public CharacterController controller;
    public Transform cam;
    public Animator anim;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public bool isRunning;

    public Transform respawnPosition;

    public bool canMove = true;

    public int Laps;
    public int deaths;

    public GameObject scoreboard;
    private void Awake()
    {
        if (PhotonNetwork.IsConnected) {

            if (!photonView.IsMine) {
                Destroy(this);
            }
        }
    }

    private void Start()
    {
        respawnPosition = GameObject.Find("Spwn}").transform;
    }
    private void Update()
    {
  
        if (PhotonNetwork.IsConnected && base.photonView.IsMine)
        {
            GameManager.Instance.SetDeathsAndLaps(deaths, Laps);
            if (GameManager.Instance.canPlay)
            {
                if (canMove)
                {
                    float horizontalInput = Input.GetAxisRaw("Horizontal");
                    float verticalinput = Input.GetAxisRaw("Vertical");

                    Vector3 direction = new Vector3(horizontalInput, 0f, verticalinput).normalized;

                    if (direction.magnitude >= 0.1f)
                    {
                        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; ;
                        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                        transform.rotation = Quaternion.Euler(0f, angle, 0f);

                        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                        controller.Move(moveDir.normalized * speed * Time.deltaTime);

                    }
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        isRunning = true;
                        speed = 10f;
                    }
                    if (Input.GetKeyUp(KeyCode.LeftShift))
                    {
                        speed = 6f;
                        isRunning = false;
                    }


                    if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
                    {
                        if (isRunning)
                        {

                            anim.SetTrigger("Run");

                        }
                        else
                        {
                            anim.ResetTrigger("Run");
                            anim.SetTrigger("StopRunning");
                            anim.ResetTrigger("StopWalk");
                            anim.SetTrigger("Walk");
                            Debug.Log("mueve");
                        }

                    }


                    if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
                    {
                        Debug.Log("nada");
                        anim.ResetTrigger("Walk");
                        anim.SetTrigger("StopWalk");
                        anim.SetTrigger("StopRunning");
                    }
                }
            }
        }
        else {
            if (canMove)
            {
                float horizontalInput = Input.GetAxisRaw("Horizontal");
                float verticalinput = Input.GetAxisRaw("Vertical");

                Vector3 direction = new Vector3(horizontalInput, 0f, verticalinput).normalized;

                if (direction.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; ;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);

                }
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    isRunning = true;
                    speed = 10f;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    speed = 6f;
                    isRunning = false;
                }


                if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
                {
                    if (isRunning)
                    {

                        anim.SetTrigger("Run");

                    }
                    else
                    {
                        anim.ResetTrigger("Run");
                        anim.SetTrigger("StopRunning");
                        anim.ResetTrigger("StopWalk");
                        anim.SetTrigger("Walk");
                        Debug.Log("mueve");
                    }

                }


                if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
                {
                    Debug.Log("nada");
                    anim.ResetTrigger("Walk");
                    anim.SetTrigger("StopWalk");
                    anim.SetTrigger("StopRunning");
                }
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "car")
        {
            //transform.parent.transform.parent.position = respawnPosition.position;
            GetComponent<AudioSource>().Play();
            deaths++;
            canMove = false;
            transform.position = respawnPosition.position;
            StartCoroutine(Wait());
            Debug.Log("Choco");
        }
        if (other.gameObject.tag == "win")
        {
            //transform.parent.transform.parent.position = respawnPosition.position;
            canMove = false;
            transform.position = respawnPosition.position;
            StartCoroutine(Wait());
            Debug.Log("vuelta");
            Laps++;
            if (Laps == GameManager.Instance.lapsToWin) {
                GameManager.Instance.OpenWinnerPanel();
                Debug.Log("Ganaste!");
            
            }
        }
    }

    IEnumerator Wait() {

        yield return new WaitForSeconds(0.1f);
        canMove = true;
    }


}
