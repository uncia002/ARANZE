using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreSceneManager : MonoBehaviour
{

    public Ranking _ranking;
    public Score _score;
    public GameObject yourScore;


    public static int[] scoreR = new int[5] { 0, 0, 0, 0, 0 }; 

    // Start is called before the first frame update
    void Start()
    {
        _ranking.RankingCalculate(_score.GetScore());
        
    }

    // Update is called once per frame
    void Update()
    {
        yourScore.GetComponent<Text>().text = "You→  " + _score.GetScore().ToString();
    }


    public int GetScoreR(int a)
    {
        return scoreR[a];
    }
    public void WriteScoreR(int a,int b)
    {
        scoreR[a] = b;
    }

    public void LoadTitle()
    {
        //SceneManager.LoadScene("Title");
    }

    public void RELoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
