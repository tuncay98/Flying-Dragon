using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class CoinIncreament : MonoBehaviour {
    public static GameObject deleted;
    public Text text;
    public Text Final;
    public static int sayi = 0;
    public GameObject endbox;



    // Use this for initialization
    void Start () {
        Sound.Play("back");
        
        text.text = "Score: "+sayi;
        //endbox.GetComponent<Renderer>().enabled = false;
        endbox.SetActive(false);

    }

    // Update is called once per frame
    void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coin") {
            sayi++;
            text.text = "Score: " + sayi;
            deleted = collision.gameObject;
            Sound.Play("coin");

        }
        if (collision.gameObject.tag == "barrier") {
            PlayerPrefs.SetInt("now", sayi);
            Sound.Stop();
            Sound.Play("gameover");
            if (!PlayerPrefs.HasKey("Coins"))
                PlayerPrefs.SetInt("Coins", sayi);
            else {
                var get = PlayerPrefs.GetInt("Coins");
                PlayerPrefs.SetInt("Coins", sayi + get);
            }

            if (!PlayerPrefs.HasKey("HighCoin")) {
                PlayerPrefs.SetInt("HighCoin", sayi);
            }
            else
            {
                int high = PlayerPrefs.GetInt("HighCoin", sayi);
                if (high < sayi) {
                    PlayerPrefs.SetInt("HighCoin", sayi);

                }
            }
            Time.timeScale = 0f;
            Final.text = "Score: " + sayi;
            //endbox.GetComponent<Renderer>().enabled = true;
            endbox.SetActive(true);
        }
    }
}
