using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDefense : MonoBehaviour {


    public GameObject fireBall;
    private Transform castPoint;
    private PlayerDirectionEnum direction;

	void Start () {
        castPoint = gameObject.GetComponentInChildren<Transform>();
    }	
	// Update is called once per frame
	void Update () {        
        Attack();
	}
    
    void Attack()
    {
        direction = gameObject.GetComponent<Move>().direction;
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
            if (PlayerDirectionEnum.RIGHT == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPoint.position.x,castPoint.position.y), Quaternion.identity);
            }
            if (PlayerDirectionEnum.LEFT == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPoint.position.x,castPoint.position.y), Quaternion.identity);
            }
        }
    }

    public void TakeDamage()
    {
        Debug.Log("Ai DOEU!!");
    }

}
