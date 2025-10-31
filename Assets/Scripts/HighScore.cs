using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HighScore : MonoBehaviour
{

    //ReadyScene Score
    [SerializeField] Text hightext;
    int high_score; 


    void Start()
    {
        high_score = PlayerPrefs.GetInt("HighScore", 0);
        PlayerPrefs.Save();
        Debug.Log(high_score);
        hightext.text = "" + high_score;
    }
    
    
}
