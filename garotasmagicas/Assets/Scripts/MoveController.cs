﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public float velocidade;
    public float delayAttack;
    public float altura;

    //Não mapeado
    public float velocidadePulo;
    public DirecaoEnum direcao;
    public Rigidbody2D rd2;

    private bool pulou = false;
    private bool isPulando = false;
    private float posicaoAtual = 0f;

    void Start() {
        rd2 = GetComponent<Rigidbody2D>();
    }

    void Update() {
        //transform.Translate(x,y,z);
        float direita = Input.GetAxisRaw(gameObject.GetComponent<Controles>().direita);
        //float cima = Input.GetButtonDown(gameObject.GetComponent<Controles>().pular);
        
        if (direita > 0)
        {
            if (DirecaoEnum.ESQUERDA == direcao)
            {
                //TODO: Flip;
            }

            direcao = DirecaoEnum.DIREITA;

            
            gameObject.transform.Translate(velocidade * Time.deltaTime, 0, 0);
        }

        if (direita < 0)
        {
            if (DirecaoEnum.DIREITA == direcao)
            {
                //TODO: Flip;
            }

            direcao = DirecaoEnum.ESQUERDA;

            gameObject.transform.Translate((velocidade * Time.deltaTime) * -1, 0, 0);
        }




        if (Input.GetButtonDown(gameObject.GetComponent<Controles>().pular) && !pulou)
        {
            float cima = Input.GetAxisRaw(gameObject.GetComponent<Controles>().pular);
            if (cima > 0)
            {
                if (DirecaoEnum.CIMA != direcao)
                {
                    direcao = DirecaoEnum.CIMA;
                }

                isPulando = true;
                pulou = true;
                posicaoAtual = gameObject.transform.position.y;
            }
            else {
                direcao = DirecaoEnum.BAIXO;
            }
            
            //rd2.velocity = new Vector2(rd2.velocity.x, 0);
            //rd2.AddForce(new Vector2(0, velocidadePulo));
        }

        handleUp();
        //if (cima < 0)
        //{
        //    direcao = DirecaoEnum.BAIXO;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (pulou)
        //{
            pulou = false;
            isPulando = false;  
        //}
    }


    private void handleUp() {
            
        if (gameObject.transform.position.y < (posicaoAtual + altura) && isPulando == true)
        {
            gameObject.transform.Translate(0, velocidadePulo * Time.deltaTime, 0);
        }
        else {
            Debug.Log("Cai");
            isPulando = false;
        }
    }


    /*
     * void Start () {
        podePular = true;
	}
	
	void Update () {
           
        float pular = Input.GetAxisRaw(gameObject.GetComponent<Controles>().pular);

        
        if (pular > 0)
        {

            //TODO: quando pular a bola de energia deve seguir a direção.
            if (podePular)
            {
                isPulou = true;
                transform.Translate(0, velocidadePulo * Time.deltaTime, 0);
            }
        }
	}

    private void canJump() {

        if (gameObject.transform.position.y >= altura) {
            podePular = false;
        }
    }

    //TODO: Se bater no teto, impedir.
    private void OnCollisionEnter(Collision collision)
    {
            
    }
     */
}