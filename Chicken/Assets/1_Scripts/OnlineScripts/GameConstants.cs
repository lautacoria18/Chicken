using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameConstants : MonoBehaviour
{
    public static GameConstants Instance;
    public Text lapsText;
    public int laps;
    public float globalVolume = 0.7f;

    void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(Instance);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }



}
