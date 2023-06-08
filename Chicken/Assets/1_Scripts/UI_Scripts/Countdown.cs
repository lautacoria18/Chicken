using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdown;
    public float timer;
    public int startSeconds = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int seconds = (int)(timer % 60);

        if (startSeconds - seconds > 0)
        {

            countdown.text = (startSeconds - seconds).ToString();
        }
        else if (startSeconds - seconds == 0)
        {

            countdown.text = "GO!";
            GameManager.Instance.canPlay = true;
        }
        else
        {
            Destroy(gameObject);

        }
    }
}
