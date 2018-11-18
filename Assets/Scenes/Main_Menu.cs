using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GoogleMobileAds.Api;


public class Main_Menu : MonoBehaviour {


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
}
