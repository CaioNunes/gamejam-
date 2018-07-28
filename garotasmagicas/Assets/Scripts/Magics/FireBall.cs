using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    public float velocity;
    public PlayerDirectionEnum direction;
    private int multiplicador = 1;

    public float lifetime;
    private float timer = 0f;
    PlayerDirectionEnum positionOriginal;
    bool tiroRicocheteado = false;

    void Update()
    {
        TimerDestruction();
        Move();
        // if (directionFutura != direction) {
        //     direction = directionFutura;
        // }

        if (tiroRicocheteado == false)
        {
            Move();
        }
        else {
            MoveRicocheteado();
        }
    }

    void MoveRicocheteado() {
        if (PlayerDirectionEnum.RIGHT == direction)
        {
            gameObject.transform.Translate(velocity * Time.deltaTime * -1, 0, 0);
        }

        if (PlayerDirectionEnum.LEFT == direction)
        {

            gameObject.transform.Translate((velocity * Time.deltaTime) , 0, 0);

            //FLIP
        }

        if (PlayerDirectionEnum.UP == direction)
        {
            Debug.Log("Estou subindo");

            gameObject.transform.Translate(0, velocity * Time.deltaTime * -1, 0);
            //FLIPP
        }

        if (PlayerDirectionEnum.DOWN == direction)
        {
            Debug.Log("Estou descendo");
            gameObject.transform.Translate(0, (velocity * Time.deltaTime), 0);
            //FLIP
        }
    }

    private void Move()
<<<<<<< HEAD
    {        
=======
    {
        Debug.Log(direction);

>>>>>>> b410a9fb85fd4c3d3a337d892905da781ef5c19d
        if (PlayerDirectionEnum.RIGHT == direction)
        {
            gameObject.transform.Translate(velocity * Time.deltaTime, 0, 0);
        }

        if (PlayerDirectionEnum.LEFT == direction)
        {
           
         gameObject.transform.Translate((velocity * Time.deltaTime) * -1, 0, 0);
  
            //FLIP
        }        

        if (PlayerDirectionEnum.UP == direction)
        {
            Debug.Log("Estou subindo");

            gameObject.transform.Translate(0, velocity * Time.deltaTime, 0);
            //FLIPP
        }

        if (PlayerDirectionEnum.DOWN == direction)  
        {
            Debug.Log("Estou descendo");
            gameObject.transform.Translate(0, (velocity * Time.deltaTime)*-1, 0);
            //FLIP
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<AttackDefense>().TakeDamage();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Shield")
        {
            tiroRicocheteado = !tiroRicocheteado;
            //collision.gameObject.GetComponent<FireBall>().redirecionarProjetil();
        }
    }
<<<<<<< HEAD
    
    private void TimerDestruction()
=======

        private void TimerDestruction()
>>>>>>> b410a9fb85fd4c3d3a337d892905da781ef5c19d
    {
        timer += Time.deltaTime;
            if(timer >= lifetime)
            {
            timer = 0;
            Destroy(this.gameObject);
            }
    }

    public void CastDirection(PlayerDirectionEnum castDirection)
    {
        direction = castDirection;
        positionOriginal = castDirection;
    }

    void flip() {
        
    }

}
