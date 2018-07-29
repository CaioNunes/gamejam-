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
        else
        {
            gameObject.transform.Translate(velocity * Time.deltaTime, 0, 0);            
        } 
    }

    private void Move()

    {
        if (PlayerDirectionEnum.LEFT == direction)
        {           
            gameObject.transform.Translate((velocity * Time.deltaTime) * -1, 0, 0);
        }
        else
        {
            gameObject.transform.Translate(velocity * Time.deltaTime, 0, 0);
        } 
    }

    void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<AttackDefense>().TakeDamage();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Shield" || collision.gameObject.tag == "Plataform")
        {
            tiroRicocheteado = !tiroRicocheteado;
            if(PlayerDirectionEnum.UP == direction || PlayerDirectionEnum.DOWN == direction)
            {
                Rotation(gameObject);
            }
            else
            {
                Flip(gameObject);
            }
        }

        if (collision.gameObject.tag == "Plataform")
        {
            Destroy(this.gameObject);
        }
    }

        private void TimerDestruction()
    {
        timer += Time.deltaTime;
            if(timer >= lifetime)
            {
            timer = 0;
            Destroy(this.gameObject);
            }
    }

    void Rotation(GameObject rotator)
    {
        Quaternion rotation = rotator.transform.localRotation;
        rotation.z *= -1;
        rotator.transform.localRotation = rotation;
    }

    void Flip(GameObject fliper)
    {
        Vector3 scale = fliper.transform.localScale;
        scale.x *= -1;
        fliper.transform.localScale = scale;
    }

    public void CastDirection(PlayerDirectionEnum castDirection)
    {
        direction = castDirection;
        positionOriginal = castDirection;
    }
}
