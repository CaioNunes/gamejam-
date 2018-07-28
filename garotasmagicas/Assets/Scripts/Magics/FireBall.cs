using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public float velocity;
    public PlayerDirectionEnum direction;

    private void Update()
    {
        if (PlayerDirectionEnum.RIGHT == direction)
        {
            gameObject.transform.Translate(velocity * Time.deltaTime, 0, 0);
        }

        if (PlayerDirectionEnum.LEFT == direction)
        {
            gameObject.transform.Translate(-1*(velocity * Time.deltaTime), 0, 0);
            //FLIP
        }

        if (PlayerDirectionEnum.RIGHT == direction)
        {
            gameObject.transform.Translate(velocity * Time.deltaTime, 0, 0);
            //FLIPP
        }

        if (PlayerDirectionEnum.UP == direction)
        {
            gameObject.transform.Translate(0, velocity * Time.deltaTime, 0);
            //FLIPP
        }

        if (PlayerDirectionEnum.DOWN == direction)
        {
            gameObject.transform.Translate(0, (velocity * Time.deltaTime)*-1, 0);
            //FLIP
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<AttackDefense>().TakeDamage();
        }

    }


    public void CastDirection(PlayerDirectionEnum castDirection)
    {
        direction = castDirection;
    }


}
