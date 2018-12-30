using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random : MonoBehaviour {

    public static float TopRandom;
    public static float DownRandom;
	// Use this for initialization
	void Start () {
        MakeIt();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void MakeIt()
    {
        TopRandom = UnityEngine.Random.Range(2.2f, 6.0f);
        DownRandom = UnityEngine.Random.Range(8.35f, 10.0f);
    }
}
