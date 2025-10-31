using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    //playScene Score
    [SerializeField] Text text;

    //해당 씬에서 loadScene 스크립트 가지고 있는 오브젝트
    public GameObject ob_lo;

    int score = 0;
    int high_score;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Level_2")
        {
            score = 990;
        }
        else if (SceneManager.GetActiveScene().name == "Level_3")
        {
            score = 1990;
        }
        high_score = PlayerPrefs.GetInt("HighScore");
        PlayerPrefs.Save();
        StartCoroutine(co_timer());

    }


    void Update()
    {
        text.text = string.Format("{0:#,#}", score);

        //점수 확인 후 맵변경 LoadScene스크립트 안의 LevelUp 메소드로 샌드 메세지

        if (score >= 1000 && SceneManager.GetActiveScene().name == "Level_1")
        {
            ob_lo.SendMessage("LevelUp", SceneManager.GetActiveScene().name);
        }
        if (score >= 2000 && SceneManager.GetActiveScene().name == "Level_2")
        {
            ob_lo.SendMessage("LevelUp", SceneManager.GetActiveScene().name);
        }



    }

    //7초에 10Score +
    IEnumerator co_timer()
    {
        while (true)
        {
            score += 10;
            yield return new WaitForSeconds(7f);
        }
    }

    void MonsterScore(int a)
    {
        score += 15;
    }

    void CompareScore()
    {
        if (score > high_score)
        {
            high_score = score;
        }
        
        PlayerPrefs.SetInt("HighScore", high_score);
        
    }

}
