using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {

    public float tempo = 0f;
    public float cont = 0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cont += Time.deltaTime;

        if (tempo >= cont) {
            SceneManager.LoadScene("Game");
        }
	}
}
