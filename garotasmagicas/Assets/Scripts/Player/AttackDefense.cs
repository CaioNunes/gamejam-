using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDefense : MonoBehaviour {


    public GameObject fireBall;
    public Transform castPointHorizontal;
    public Transform castPointUP;
    public Transform castPointDOWN;
    public AudioClip cast;
    public float fireHate;
    public bool canAttack;
    private float timer;
    private PlayerDirectionEnum direction;

    void Start () {
        canAttack = true;        
    }	
	// Update is called once per frame
	void Update () {
        HandleDirection();
        Attack();
        FireHateTimer();
	}
    
    void Attack()
    {
        if (Input.GetButtonDown(gameObject.GetComponent<Controls>().attack)&&canAttack)
        {            
            fireBall.GetComponent<FireBall>().CastDirection(direction);
            if (PlayerDirectionEnum.UP == direction)
            {                
                Instantiate(fireBall as GameObject, new Vector2(castPointUP.position.x,castPointUP.position.y), Quaternion.identity);                
            }
            if (PlayerDirectionEnum.DOWN == direction)
            {                
                Instantiate(fireBall as GameObject, new Vector2(castPointDOWN.position.x,castPointDOWN.position.y), Quaternion.identity);                
            }
            if (PlayerDirectionEnum.RIGHT == direction || PlayerDirectionEnum.LEFT == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPointHorizontal.position.x,castPointHorizontal.position.y), Quaternion.identity);
            }
            canAttack = false;
            AudioSource.PlayClipAtPoint(cast, transform.position);
        }
    }


    void HandleDirection()
    {
        float horizontal = Input.GetAxisRaw(gameObject.GetComponent<Controls>().horizontalMove);
        float vertical = Input.GetAxisRaw(gameObject.GetComponent<Controls>().verticalMove);

        if (horizontal > 0)
        {
            direction = PlayerDirectionEnum.RIGHT;
        }
        if (horizontal < 0)
        {
            direction = PlayerDirectionEnum.LEFT;
        }
        if (vertical > 0)
        {
            direction = PlayerDirectionEnum.UP;
        }
        if (vertical < 0)
        {
            direction = PlayerDirectionEnum.DOWN;
        }
    }  
    
    void FireHateTimer()
    {
        if(canAttack == false)
        {
            timer += Time.deltaTime;
            if(timer >= fireHate)
            {
                canAttack = true;
                timer = 0;
            }
        }
    }

    public void TakeDamage()
    {
        Destroy(this.gameObject);
    }

}
