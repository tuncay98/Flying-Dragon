using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour {

    public Camera camera1;
    public GameObject coin;

    public float speed = 0;
    private List<GameObject> list = new List<GameObject>();
    private int get;
    
    // Use this for initialization
    void Start () {

        InvokeRepeating("GenerateCoin", 2.5f, 2.5f);

    }
	
	// Update is called once per frame
	void Update () {

        if (CoinIncreament.deleted != null) {
            CoinIncreament.deleted.SetActive(false);
        }

        foreach (var item in list)
        {
            if (item != null && item.activeSelf)
            {
                item.transform.Translate(speed * Time.deltaTime, 0, 0);
            }

        }

    }

    void GenerateCoin()
    {
        GameObject createdcoin = Instantiate(coin, new Vector3(camera1.transform.position.x+11, camera1.transform.position.y + UnityEngine.Random.Range(-4.0f, 4.0f), 0), coin.transform.rotation) as GameObject;


        list.Add(createdcoin);

        Destroy(createdcoin, 8);
       

    }

}
