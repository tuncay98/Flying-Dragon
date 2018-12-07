using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;


public class Main_Menu : MonoBehaviour {

    public Button high;
    public Button middle;
    public Button low;
    public Text SoundText;
    public Text TotalCoins;
    private void Start()
    {
        TotalCoin();
        Hide();
        if(AudioListener.pause)
            SoundText.text = "Sound: OFF";
        else
            SoundText.text = "Sound: On";
    }

    public void Hide()
    {
        high.gameObject.SetActive(false);
        middle.gameObject.SetActive(false);
        low.gameObject.SetActive(false);
    }
    public void Unhide()
    {
        high.gameObject.SetActive(true);
        middle.gameObject.SetActive(true);
        low.gameObject.SetActive(true);
    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);

    }

    public void StartGame()
    {

        Sound.Stop();
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
        CoinIncreament.sayi = 0;
    }

    public void ResetGame() {
        Sound.Stop();
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.name);
        Time.timeScale = 1f;
        CoinIncreament.sayi = 0;
    }

    public void ReturnMenu() {
        Sound.Stop();
        SceneManager.LoadScene("MainMenu");
        Sound.Play("mainmenu");


    }

    public static void Resume() {
        Sound.Stop();
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.name);
        Time.timeScale = 1f;
        CoinIncreament.sayi = PlayerPrefs.GetInt("now");


    }

    public void Mute()
    {
        
        if (!AudioListener.pause)
        {
            AudioListener.pause = true; 
            SoundText.text = "Sound: OFF";
        }
        else
        {
            AudioListener.pause = false;
            
            SoundText.text = "Sound: ON";
        }
    }

    public void TotalCoin()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            var getcoins = PlayerPrefs.GetInt("Coins");
            TotalCoins.text = getcoins.ToString();
        }
        else
            TotalCoins.text = "0";
    }
}
