﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Retry : MonoBehaviour {

    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown) {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            SceneManager.LoadScene("Game");
        }
	}
}
