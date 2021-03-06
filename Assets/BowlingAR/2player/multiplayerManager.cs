﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class multiplayerManager : MonoBehaviour
{
    public Rigidbody rb;


    public int[] scores;
    public int round;
    public float maxTime;
    public float minSwipeDist;

    float startTime;
    float endTime;


    public TMP_Text[] boards;

    Vector3 startPos;
    Vector3 endPos;
    float swipeDistance;
    float swipeTime;

    public bool kk;
    public GameObject plane;
    public GameObject[] obs;
    public int scoreF;

    // Start is called before the first frame update
    void Start()
    {
      
        //  rb = GetComponent<Rigidbody>();

        scores = new int[10];
    }

    // Update is called once per frame

    public GameObject playerAText;
    public GameObject playerBText;
    void Update()
    {
        if(round%2 == 0)
        {
            playerAText.SetActive(true);
            playerBText.SetActive(false);
        }

        if (round % 2 != 0)
        {
            playerAText.SetActive(false);
            playerBText.SetActive(true);
        }

        if (Input.touchCount > 0 && kk == false)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                {
                    SwipeFunc();
                }
            }
        }



    }
    public Text score;
    void SwipeFunc()
    {
        Vector2 distance = endPos - startPos;


        Vector3 ballMotion = new Vector3(-distance.x, plane.transform.position.y, -distance.y);

        rb.AddForce(ballMotion * 6);

        kk = true;

        StartCoroutine(Score());
    }

    IEnumerator Score()
    {
        yield return new WaitForSeconds(8);

        obs = GameObject.FindGameObjectsWithTag("obs");
        Debug.Log("coroutine chala");
        foreach (GameObject ob in obs)
        {

            /*     if(ob.transform.rotation.eulerAngles.x >20 || ob.transform.rotation.eulerAngles.y > 20 || ob.transform.rotation.eulerAngles.z > 20)
             {


                 Debug.Log("score badha");
                 scoreF++;

             } */
            if (ob.transform.localEulerAngles.x > 70 || ob.transform.localEulerAngles.y > 70 || ob.transform.localEulerAngles.z > 70)
            {
                Debug.Log("score badha");
                scoreF++;


            }
        }
        score.text = scoreF.ToString();
        scores[round] = scoreF;
        resetScene();
    }


    public GameObject panel;

    public void closePanel()
    {
        panel.SetActive(false);
    }


    public GameObject gameOver;
    public void resetScene()
    {
        if (round < 9)
        {
            LeanTween.scaleY(boards[round].gameObject.transform.parent.gameObject, 1f, 1f);
            boards[round].text = scores[round].ToString();
            scoreF = 0;
            round++;

            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }
        else
        {
            LeanTween.scaleY(boards[round].gameObject.transform.parent.gameObject, 1f, 1f);

            rb.gameObject.SetActive(false);
            Debug.Log("game over");
            gameOverdone();

        }
        foreach (GameObject ob in obs)
        {

            ob.GetComponent<Rigidbody>().useGravity = false;
            ob.GetComponent<Rigidbody>().velocity = Vector3.zero;
            ob.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            ob.transform.localEulerAngles = new Vector3(0, 0, 0);
            ob.transform.localPosition = new Vector3(0, 0, 0);


            kk = false;
        }
        rb.gameObject.transform.localPosition = new Vector3(0.95f, -2.78f, 3.84f);
        // rb.velocity = Vector3.zero;
        foreach (GameObject ob in obs)
        {
            ob.GetComponent<Rigidbody>().useGravity = true;

        }
    }


    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public GameObject groundPlane;

    public void planeDestroyer()
    {
        groundPlane.SetActive(false);
    }


    public void menu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public Text winner;
    public int scoreA;
    public int scoreB;

    public Text Ascore;
    public Text Bscore;
    public void gameOverdone()
    {
        for(int i = 0; i < 10; i++)
        {
            if(i%2 == 0)
            {
                scoreA += scores[i];
            }
            else
            {
                scoreB += scores[i];
            }
        }


        if (scoreA > scoreB)
        {
            winner.text = "PLAYER A WINS!!!";

            winner.color = new Color(0.945f, 0.1568f, 0.157f);
        }
        else
        {
            winner.text = "PLAYER B WINS!!!";

            winner.color = new Color(0.3412f, 0.7412f,0.68235f) ;
        }


        Ascore.text = "A: " + scoreA.ToString();
        Bscore.text = "B: " + scoreB.ToString();
        gameOver.SetActive(true);
        LeanTween.scale(gameOver, Vector3.one, 1f);
    }
}
