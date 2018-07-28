using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public float horizontalSpeed;  
    public float jumpForce;

    private bool canJump;

    public Rigidbody2D rigidBody;
    public GameObject fireBall;
    public PlayerDirectionEnum direction;
    public PlayerDirectionEnum directionTop;
    
    // Use this for initialization
    void Start () {
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
        float jump = Input.GetAxisRaw(gameObject.GetComponent<Controls>().verticalMove);
        if (jump > 0 && canJump)
        {
            directionTop = PlayerDirectionEnum.UP;

            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0);
            rigidBody.AddForce(new Vector2(0, jumpForce));
            canJump = false;
        }        
        if(Input.GetAxisRaw(gameObject.GetComponent<Controls>().verticalMove) < 0)
        {
            directionTop = PlayerDirectionEnum.DOWN;            
        }
    }     
    void HorizontalMove()
    {
        float horizontalmove = Input.GetAxisRaw(gameObject.GetComponent<Controls>().horizontalMove);
            if(horizontalmove > 0){
                if (direction == PlayerDirectionEnum.LEFT){
                    flip();
                }

               direction = PlayerDirectionEnum.RIGHT;
               gameObject.transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
            }
        if (Input.GetAxisRaw(gameObject.GetComponent<Controls>().horizontalMove) < 0)
        {
            if (PlayerDirectionEnum.RIGHT == direction)
            {
                flip();
            }
            direction = PlayerDirectionEnum.LEFT;
            gameObject.transform.Translate(-horizontalSpeed * Time.deltaTime, 0, 0);
        }
    }

    void flip() {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
