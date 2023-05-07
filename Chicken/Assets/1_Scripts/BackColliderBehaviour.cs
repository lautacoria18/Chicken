using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackColliderBehaviour : MonoBehaviour
{
    public Car_Behaviour car;
    // Start is called before the first frame update
    void Start()
    {
        car = transform.parent.gameObject.GetComponent<Car_Behaviour>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "FrontCollider") {
            transform.parent.gameObject.GetComponent<Car_Behaviour>().speed= collision.gameObject.transform.parent.gameObject.GetComponent<Car_Behaviour>().speed + 1;
            Debug.Log("ASSDFAf");
        }
    }
}
