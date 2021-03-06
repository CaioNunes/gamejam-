﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour {

    public float horizontalSpeed;  
    public float jumpForce;
    public int life;
    public bool isAlive;
    public bool canJump;

    public Rigidbody2D rigidBody;
    public GameObject fireBall;
    public PlayerDirectionEnum direction;
    public PlayerDirectionEnum directionTop;
    Animator animator;
    public AudioClip explodiu;
    bool jaVerifiquei = false;
    bool canWalk = true;

    public float deathTimer = 0f;
    float timerMorte = 0f;

    private static int qtdPlayers = 2;
    
    // Use this for initialization
    void Start () {
        life = 1;
        isAlive = true;
        canJump = true;        
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {
        HorizontalMove();
        Jump();
        Alive();

        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            Debug.Log("VITORIA!!!");
        }
        else if (GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            Debug.Log("EMPATE!!!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Plataform" || collider.gameObject.tag == "Player")
        {
            canJump = true;
        }
    }

    void Jump()
    {
        float jump = Input.GetAxisRaw(gameObject.GetComponent<Controls>().verticalMove);
        if (jump > 0 && canJump && LevelManager.canMove)
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

        if (horizontalmove > 0 && canWalk && LevelManager.canMove){
                if (direction == PlayerDirectionEnum.LEFT){
                    flip();
                }

               direction = PlayerDirectionEnum.RIGHT;
               gameObject.transform.Translate(horizontalSpeed * Time.deltaTime, 0, 0);
            }

        if (horizontalmove < 0 && canWalk)
        {
            if (PlayerDirectionEnum.RIGHT == direction)
            {
                flip();
            }
            direction = PlayerDirectionEnum.LEFT;
            gameObject.transform.Translate(-horizontalSpeed * Time.deltaTime, 0, 0);
        }
    }

    void Alive()
    {
        if (life <= 0 && !jaVerifiquei)
        {
            isAlive = false;
            jaVerifiquei = true;
            animator.Play("Death");
            gameObject.GetComponent<Move>().canWalk = false;
            AudioSource.PlayClipAtPoint(explodiu, transform.position);
        }

        if (!isAlive)
        {
            timerMorte += Time.deltaTime;
            if (timerMorte >= deathTimer) {
               
                    Destroy(this.gameObject);
                
            }
        }
    }


    void flip() {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
