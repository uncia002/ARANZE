using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public Score _score;
    public GameObject _unitychan;
    public GameObject ThisIsYou;
    public ScoreSceneManager _scoreSceneManager;


    public int[] scoreR = new int[5];
    public bool isHighScore = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            scoreR[i] = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 5; i++)
        {
            scoreR[i] = _scoreSceneManager.GetScoreR(i);
        }

        Debug.Log(scoreR[0]);
        this.GetComponent<Text>().text = "1st\t" + scoreR[0] +
            "\n2nd\t" + scoreR[1].ToString() +
            "\n3rd\t" + scoreR[2].ToString() +
            "\n4th\t" + scoreR[3].ToString() +
            "\n5th\t" + scoreR[4].ToString();
    }


    public void RankingCalculate(int highScore)
    {
        for (int j = 0; j < 5; j++)
        {
            scoreR[j] = _scoreSceneManager.GetScoreR(j);
        }


        int i = 0;
        isHighScore = false;

        for (; i < 5; i++)
        {
            //スコア更新していたら
            if (highScore > scoreR[i])
            {
                isHighScore = true;
                goto Hotel;
            }
            
        }
        Hotel:;

        //ランキング更新処理
        if (isHighScore)
        {
            int stack = scoreR[i];
            scoreR[i] = highScore;
            int z = i;
            for (i+=1; i < 4; i++)
            {
                scoreR[i] = stack;
                stack = scoreR[i + 1];
            }
            scoreR[4] = stack;

            _unitychan.GetComponent<Animator>().SetBool("glad", true);

            ThisIsYou.transform.localPosition = new Vector3(-200, 260 - z * 80, 0);
            ThisIsYou.SetActive(true);
        }
        else
        {

            ThisIsYou.SetActive(false);
            _unitychan.GetComponent<Animator>().SetBool("sad", true);
        }

    for(int j = 0; j < 5; j++)
        {
            _scoreSceneManager.WriteScoreR(j, scoreR[j]);
        }

    }

}
