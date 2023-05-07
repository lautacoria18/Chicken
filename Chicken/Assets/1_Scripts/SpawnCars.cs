using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public bool StartFromRight;
    public Car_Behaviour[] childrens;
    public bool firstTime = true;

  
    void Start()
    {
        childrens = GetComponentsInChildren<Car_Behaviour>();
        foreach (Car_Behaviour objet in childrens) { 
        
            objet.gameObject.SetActive(false);
        }
            StartCoroutine(SpawnCar());
    }

    private IEnumerator SpawnCar() {

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

    private bool CheckForChildrens() {

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (!gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
      

    // Update is called once per frame
 
}
