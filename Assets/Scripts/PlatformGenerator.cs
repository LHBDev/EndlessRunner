using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

    public GameObject thePlatform;

    public float distanceBetween;

    public float timer = 0f;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
        if(timer>1f)
        { 

            Instantiate(thePlatform, transform.position, transform.rotation);

            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
