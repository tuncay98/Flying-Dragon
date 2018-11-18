using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBoxMove : MonoBehaviour
{

    public GameObject box;

    public float speed = 0;

    public Camera camera1;


    private List<GameObject> list = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        Invoke("GenerateBox", 2.5f);

    }

    // Update is called once per frame
    void Update()
    {


        foreach (var item in list)
        {
            if (item != null)
            {
                item.transform.Translate(speed * Time.deltaTime, 0, 0);
            }

        }

    }

    private void GenerateBox()
    {

        Quaternion rotation = Quaternion.Euler(180, 0, 0);

        GameObject topadding = Instantiate(box, new Vector3(camera1.transform.position.x + 5f, camera1.transform.position.y + UnityEngine.Random.Range(2.9f, 4.0f), 0), rotation) as GameObject;

        list.Add(topadding);

        Destroy(topadding, 5);

    }


}

