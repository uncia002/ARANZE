using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public bool isGameOver;
    public GameObject unitychan;
    public GameObject gameover;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        Score.score = 20;
    }

    // Update is called once per frame
    void Update()
    {
        if (unitychan.GetComponent<Transform>().position.y < -3)
        {
            isGameOver = true;
        }
        {

        }

        if (isGameOver)
        {
            
            gameover.SetActive(true);
        }
        else
        {
           

        }
        
    }


    public void NEXT()
    {
        SceneManager.LoadScene("ScoreScene");
    }
}
