using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDefense : MonoBehaviour {

    public GameObject shield;
    public GameObject fireBall;
    public Transform castPointHorizontal;
    public Transform castPointUP;
    public Transform castPointDOWN;
    public Transform castPointShield;
    public AudioClip cast;
    public float fireHate;
    public float shieldCoolDown;
    public bool canAttack;
    public bool canShield;
    private float timerAttack;
    private float timerShield;
    Animator animator;
    
    private PlayerDirectionEnum direction;

    void Start () {
        canAttack = true;
        canShield = true;
        animator = GetComponent<Animator>();        
    }	
	// Update is called once per frame
	void Update () {
        HandleDirection();
        Attack();
        Defense();
        FireHateTimer();
        ShieldCooldownTimer();        
	}
    
    void Attack()
    {
        if (Input.GetButtonDown(gameObject.GetComponent<Controls>().attack) && canAttack)
        {
            animator.Play("Attack");
            fireBall.GetComponent<FireBall>().CastDirection(direction);
            if (PlayerDirectionEnum.UP == direction)
            {                
                Instantiate(fireBall as GameObject, new Vector2(castPointUP.position.x, castPointUP.position.y), Quaternion.Euler(0f, 0f, 90f));                
            }
            if (PlayerDirectionEnum.DOWN == direction)
            {                
                Instantiate(fireBall as GameObject, new Vector2(castPointDOWN.position.x,castPointDOWN.position.y), Quaternion.Euler(0f, 0f, -90f));                
            }
            if (PlayerDirectionEnum.RIGHT == direction)
            {
                Instantiate(fireBall as GameObject, new Vector2(castPointHorizontal.position.x,castPointHorizontal.position.y), Quaternion.identity);
            }
            if (PlayerDirectionEnum.LEFT == direction)
            {
                Flip(fireBall);
                Instantiate(fireBall as GameObject, new Vector2(castPointHorizontal.position.x, castPointHorizontal.position.y), Quaternion.identity);
                Flip(fireBall);
            }
            canAttack = false;
            AudioSource.PlayClipAtPoint(cast, transform.position);
        }
    }

    void Defense()
    {
        //Se o botão de defesa foi desparado e o seu cooldown está zerado.
        if (Input.GetButtonDown(gameObject.GetComponent<Controls>().shield) && canShield)
        {
            GameObject newShield = Instantiate(shield, castPointShield.position, castPointShield.rotation);
            newShield.transform.SetParent(castPointHorizontal);

            canShield = false;
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
            timerAttack += Time.deltaTime;
            if(timerAttack >= fireHate)
            {
                canAttack = true;
                timerAttack = 0;
            }
        }
    }

    void ShieldCooldownTimer()
    {
        if (canShield == false)
        {
            timerShield += Time.deltaTime;
            if (timerShield >= shieldCoolDown)
            {
                canShield = true;
                timerShield = 0;
            }                
        }
    }  

    void Flip(GameObject fliper)
    {
        Vector3 scale = fliper.transform.localScale;
        scale.x *= -1;
        fliper.transform.localScale = scale;
    }

    public void TakeDamage()
    {
        gameObject.GetComponent<Move>().life -= 1; 
    }    

}
