using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    float counter = 0;
    float pauseTime = 6.5f;
    int matchTime = 60;

    float time;


    // Use this for initialization
    void Start () {
        PauseAndResume();
        time = matchTime;
        //StartCoroutine(ResumeAfterNSeconds(pauseTime + matchTime));
    }
	
	// Update is called once per frame
	void Update () {
		 time -= Time.deltaTime;
        Debug.Log(Mathf.RoundToInt(time));
       // Debug.Log((int)time);
	}


    void PauseAndResume()
    {
        Time.timeScale = 0;
        //Display Image here
        StartCoroutine(ResumeAfterNSeconds(pauseTime));
    }

    IEnumerator ResumeAfterNSeconds(float timePeriod)
    {
        yield return new WaitForEndOfFrame();
        counter += Time.unscaledDeltaTime;
        if (counter < timePeriod)
            StartCoroutine(ResumeAfterNSeconds(pauseTime));
        else
        {
            Time.timeScale = 1;
            counter = 0;
        }
    }


}
