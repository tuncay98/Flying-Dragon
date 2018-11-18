using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    // Use this for initialization

    public static AudioClip coin;
    public static AudioClip menu;
    public static AudioClip back;

    static AudioSource source;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("sound");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    
    void Start () {


        coin = Resources.Load<AudioClip>("coinsound");

        back = Resources.Load<AudioClip>("back");

        menu = Resources.Load<AudioClip>("mainmenu");


        source = GetComponent<AudioSource>();


        Sound.Play("mainmenu");

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Play(string name)
    {
        if (name == "coin") {
            source.PlayOneShot(coin);
        }
        if (name == "mainmenu")
        {
            source.PlayOneShot(menu);
            
        }
        if (name == "back")
        {
            source.PlayOneShot(back);

        }
    }
    public static void Stop()
    {
        source.Stop();
    }
}
