using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using System;

public class HighScore : MonoBehaviour {


    public Text txt;
    private int high;


    void Start()
    {





        if (PlayerPrefs.HasKey("HighCoin"))
        {
            high = PlayerPrefs.GetInt("HighCoin", 0);
            txt.text = "High Score: " + high;
        }


    }



}
