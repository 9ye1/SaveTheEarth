using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour, IPointerDownHandler
{
    
    
    public void OnPointerDown(PointerEventData data)
    {
        if (SceneManager.GetActiveScene().name == "StartScene")
        {
            SceneManager.LoadScene("ReadyScene");
        }
        if (SceneManager.GetActiveScene().name == "ReadyScene")
        {
            SceneManager.LoadScene("Level_1");
        }
        
    }

    public void LevelUp(string sceneName)
    {
        if (sceneName == "Level_1")
        {
            SceneManager.LoadScene("Level_2");
        }
        if (sceneName == "Level_2")
        {
            SceneManager.LoadScene("Level_3");
        }

    }

}

