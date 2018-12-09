using UnityEngine;
using System.Collections;
using GoogleMobileAds.Api;
using System;

public class PlayerMove : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 direction;
    private bool directionChosen;
    public float speed = 16f;
    public GameObject player;
    public Camera camera1;
    float height;

    private void Start()
    {
        string appId = "ca-app-pub-6448871441563979~1039328394";
        MobileAds.Initialize(appId);
        RequestInterstitial();
        height = 2f * camera1.orthographicSize;
        
    }
    private void Update()
    {
        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on touch phase.
            switch (touch.phase)
            {
                // Record initial touch position.
                case TouchPhase.Began:
                    startPos = touch.position;
                    directionChosen = false;
                    break;

                // Determine direction by comparing the current touch position with the initial one.
                case TouchPhase.Moved:
                    direction = touch.position - startPos;

                        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + (direction.y/speed)*Time.deltaTime, 0);

                    break;

                // Report that a direction has been chosen when the finger is lifted.
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if (directionChosen)
        {
            // Something that uses the chosen direction...
        }
        
        if (player.transform.position.y > camera1.transform.position.y + (height / 2)) {

            player.transform.position = new Vector3(player.transform.position.x, camera1.transform.position.y + (height / 2), 0);
        }
        if (player.transform.position.y < camera1.transform.position.y - (height / 2))
        {

            player.transform.position = new Vector3(player.transform.position.x, camera1.transform.position.y - (height / 2), 0);
        }
    }


    private InterstitialAd interstitial;
    private void RequestInterstitial()
    {

        string adUnitId = "ca-app-pub-6448871441563979/3395821006";
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712";




        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);



        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;
        // Called when the ad click caused the user to leave the application.
        this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;

        AdRequest request = new AdRequest.Builder().Build();

        this.interstitial.LoadAd(request);



    }

    public void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            Sound.Stop();
            this.interstitial.Show();
        }
    }


    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Main_Menu.Resume();
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
        Main_Menu.Resume();

    }

    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }

}