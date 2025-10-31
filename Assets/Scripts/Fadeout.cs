using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fadeout : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    float fades = 0.0f;
    float time = 0;
    
    void Update()
    {
        
        time += Time.deltaTime;
        if(fades < 1.0f && time >= 0.1f)
        {
            fades += 0.03f;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }
        else if(fades > 1.0f)
        {
            time = 0;
            SceneManager.LoadScene("ReadyScene");
           
        }
    }
    
}
