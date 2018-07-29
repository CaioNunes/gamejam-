using System;
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
    Animator animator;

    public float contador;
    float timer = 0;

    // Use this for initialization
    void Start () {
        canJump = true;
        PauseAndResume();
        animator = GetComponent<Animator>();
    }

    void PauseAndResume()
    {
        Time.timeScale = 0;
        //Display Image here
        StartCoroutine(ResumeAfterNSeconds(5.0f));
    }

    
    IEnumerator ResumeAfterNSeconds(float timePeriod)
    {
        yield return new WaitForEndOfFrame();
        timer += Time.unscaledDeltaTime;
        if (timer < timePeriod)
            StartCoroutine(ResumeAfterNSeconds(3.0f));
        else
        {
            Time.timeScale = 1;                //Resume
            timer = 0;
        }
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
            animator.Play("Jump");
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
        animator.SetFloat("speed", Mathf.Abs(horizontalmove));

        if (horizontalmove > 0){
                if (direction == PlayerDirectionEnum.LEFT){
                    flip();
                }

               direction = PlayerDirectionEnum.RIGHT;
               gameObject.transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
            }

        if (horizontalmove < 0)
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
