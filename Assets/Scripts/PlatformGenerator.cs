using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject[] thePlatform;

    public float timer = 0f;

    private int number;

    // Use this for initialization
    void Start () {
        number = 0;
	}
	
	// Update is called once per frame
	void Update () {
        
        if(timer>1f)
        {
            
            Instantiate(thePlatform[number], transform.position, transform.rotation);
            number = Mathf.FloorToInt(Random.Range(0f, 2.9f));
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
