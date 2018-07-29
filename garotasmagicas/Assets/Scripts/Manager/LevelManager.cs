using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    float counter = 0;
    float pauseTime = 6.5f;
    int matchTime = 60;
    public GameObject contador;
    float time;
    float numero = 5f;

    public Sprite tres;
    public Sprite dois;
    public Sprite um;

    public static bool canAttack = false;
    public static bool canMove = false;

    // Use this for initialization
    void Start () {
        PauseAndResume();
        time = matchTime;
        canAttack = false;
        canMove = false;
    }
	
	// Update is called once per frame
	void Update () {
		 time -= Time.deltaTime;
        numero -= Time.deltaTime;
        //Debug.Log(numero);

        if (GameObject.FindGameObjectsWithTag("Player").Length == 1)
        {
            GameObject vencedor = GameObject.FindGameObjectWithTag("Player");
            DontDestroyOnLoad(vencedor);
            SceneManager.LoadScene("Win");            
            Destroy(this.gameObject);

        }

    }

    void PauseAndResume()
    {
        Time.timeScale = 0;
        //Display Image here
        StartCoroutine(ResumeAfterNSeconds(pauseTime));
    }

    IEnumerator ResumeAfterNSeconds(float timePeriod)
    {
        yield return new WaitForEndOfFrame();
        counter += Time.unscaledDeltaTime;
        if (counter < timePeriod)
        {
            StartCoroutine(ResumeAfterNSeconds(pauseTime));

            if (counter >= 6.2)
            {
                contador.GetComponent<SpriteRenderer>().sprite = um;
            }

            if (counter >= 4.7 && counter < 6.2)
            {
                contador.GetComponent<SpriteRenderer>().sprite = dois;

            }

            if (counter >= 3 && counter < 4.7)
            {
                contador.GetComponent<SpriteRenderer>().sprite = tres;

            }
        }
        else
        {
            Time.timeScale = 1;
            counter = 0;
            Destroy(contador);
            canAttack = true;
            canMove = true;
        }

     
    }


}
