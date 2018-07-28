using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float horizontalSpeed;    
    public float jumpHight;
    public Rigidbody2D rigidBody;

    public GameObject fireBall;

    private Transform castPoint;
    public PlayerDirectionEnum direction;
  

    // Use this for initialization
    void Start () {
        castPoint = gameObject.GetComponentInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        HorizontalMove();
        Jump();
        Attack();
    }

    void Jump()
    {
        float jump = Input.GetAxisRaw(gameObject.GetComponent<Controls>().jump);
        if (jump > 0)
        {
            direction = PlayerDirectionEnum.UP;
            
        }
        if(jump < 0)
        {
            direction = PlayerDirectionEnum.DOWN;
        }
    }
     
    void HorizontalMove()
    {
        float horizontalmove = Input.GetAxisRaw(gameObject.GetComponent<Controls>().horizontalMove);
            if(horizontalmove > 0)
            {
                if (PlayerDirectionEnum.LEFT == direction)
                {
                    //Flip!!
                }
               direction = PlayerDirectionEnum.RIGHT;
               gameObject.transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
            }

        if (horizontalmove < 0)
        {
            if (PlayerDirectionEnum.RIGHT == direction)
            {
                //Flip!!
            }
            direction = PlayerDirectionEnum.LEFT;
            gameObject.transform.Translate(-horizontalSpeed * Time.deltaTime, 0, 0);
        }
    }

    void Attack()
    {
        if (Input.GetButtonDown(gameObject.GetComponent<Controls>().attack))
        {
            fireBall.GetComponent<FireBall>().CastDirection(direction);

            if (PlayerDirectionEnum.UP == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPoint.position.x, castPoint.position.y), Quaternion.identity);
            }
            if (PlayerDirectionEnum.DOWN == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPoint.position.x, castPoint.position.y), Quaternion.identity);
            }
            if (PlayerDirectionEnum.RIGHT == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPoint.position.x, castPoint.position.y), Quaternion.identity);
            }
            if (PlayerDirectionEnum.LEFT == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPoint.position.x, castPoint.position.y), Quaternion.identity);
            }            
        }
    }

    public void TakeDamage()
    {
        Debug.Log("Ai DOEU!!");
    }


}
