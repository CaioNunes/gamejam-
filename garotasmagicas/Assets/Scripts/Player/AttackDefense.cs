using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDefense : MonoBehaviour {


    public GameObject fireBall;
    public Transform castPoint;
    private PlayerDirectionEnum direction;
    public AudioClip cast;

	void Start () {
        
    }	
	// Update is called once per frame
	void Update () {
        HandleDirection();
        Attack();
	}
    
    void Attack()
    {
        if (Input.GetButtonDown(gameObject.GetComponent<Controls>().attack))
        {
            fireBall.GetComponent<FireBall>().CastDirection(direction);
           
            if (PlayerDirectionEnum.UP == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPoint.position.x,castPoint.position.y), Quaternion.identity);
            }
            if (PlayerDirectionEnum.DOWN == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPoint.position.x,castPoint.position.y), Quaternion.identity);
            }
            if (PlayerDirectionEnum.RIGHT == direction || PlayerDirectionEnum.LEFT == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPoint.position.x,castPoint.position.y), Quaternion.identity);
            }
            
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

    public void TakeDamage()
    {
        Destroy(this.gameObject);
    }

}
