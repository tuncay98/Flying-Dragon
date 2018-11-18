using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moving : MonoBehaviour {

    // Use this for initialization
    public float speed = 0;


    void Start () {
        
    }


    // Update is called once per frame
    void Update () {

        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * speed)%1, 0f);        
	}
}
