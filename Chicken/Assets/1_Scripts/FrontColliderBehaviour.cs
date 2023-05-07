using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontColliderBehaviour : MonoBehaviour
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
}
