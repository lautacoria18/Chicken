using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdCameraMovement : MonoBehaviour
{
    public Transform orientation, player, playerObj;
    public Rigidbody rb;

    public float rotationSpeed;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        Debug.Log(Input.GetAxis("Horizontal"));
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        //float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = orientation.forward  + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero) { 
        
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }

}
