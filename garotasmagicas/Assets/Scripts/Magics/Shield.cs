using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

   // public float shieldTimer = 5.0f;
   // public bool shieldPowerUpActivated = true;

    void Start()
    {
   //     shieldPowerUpActivated = true;
    }

    void Update()
    {

      //  if (shieldTimer <= 0.0f)
     //   {
     //       shieldPowerUpActivated = false;
     //       Destroy(this.gameObject);
     //   }
     //   shieldTimer -= Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
     
    }

    void OnTriggerStay2D(Collider2D collision)
    {

        //     if (collision.gameObject.tag == "Projetil")
        //      {
        //          Debug.Log("Triguei !");
        //          collision.gameObject.SendMessage("redirecionarProjetil");
        //collision.gameObject.GetComponent<FireBall>().redirecionarProjetil();
        //      }
        //  }
    }
}
