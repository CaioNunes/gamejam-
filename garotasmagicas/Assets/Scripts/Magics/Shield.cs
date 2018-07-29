using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public float shieldTimer = 5.0f;

    void Start()
    {
       
    }

    void Update()
    {
        shieldTimer -= Time.deltaTime;

        if (shieldTimer <= 0.0f)
        {
            Destroy(this.gameObject);
        }        
    }     
}
