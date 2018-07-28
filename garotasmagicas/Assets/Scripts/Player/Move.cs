using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float horizontalSpeed;  
    public float jumpForce;

    public bool canJump;

    public Rigidbody2D rigidBody;
    public GameObject fireBall;
    public PlayerDirectionEnum direction;

    private Transform castPoint;

    // Use this for initialization
    void Start () {
        castPoint = gameObject.GetComponentInChildren<Transform>();
        canJump = true;
    }
    
	// Update is called once per frame
	void Update () {
        HorizontalMove();
        Jump();        
    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Plataform")
        {
            canJump = true;
        }
    }

    void Jump()
    {        
        float jump = Input.GetAxisRaw(gameObject.GetComponent<Controls>().jump);
        if (jump > 0 && canJump)
        {
            direction = PlayerDirectionEnum.UP;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce));
            canJump = false;

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
}
