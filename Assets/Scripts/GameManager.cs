using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerController thePlayer;
    private Vector3 playerStartPoint;

    public PlatformGenerator platforms;

    public ScrollUV scrolling;

    public GameObject pauseMenu;

    private bool pause = false;
    // Use this for initialization
    void Start () {
        playerStartPoint = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            pause = !pause;

        if (pause)
        {
            pauseMenu.SetActive(true);
            thePlayer.GetComponent<AudioSource>().Pause();
            Time.timeScale = 0f;
        }

        else
        {
            pauseMenu.SetActive(false);
            thePlayer.GetComponent<AudioSource>().UnPause();
            Time.timeScale = 1f;
        }
    }

    public void RestartGame()
    {
        StartCoroutine(RestartGameCo());
    }

    public IEnumerator RestartGameCo()
    {
        platforms.pause = true;
        thePlayer.gameObject.SetActive(false);
        gameObject.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(3f);
        thePlayer.transform.position = playerStartPoint;
        thePlayer.gameObject.SetActive(true);
        platforms.timer = 0f;
        platforms.pause = false;
    }
}
