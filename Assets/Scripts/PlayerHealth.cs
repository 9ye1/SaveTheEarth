using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    private float playerHealth;
    public Image img4;
    public Sprite img3;
    public Sprite img2;
    public Sprite img1;
    //캔버스 비활성화/활성화
    public GameObject gameover;
    public GameObject origin;
    public GameObject attack;
    public GameObject warnImg;
    //ScoreScript 에 SendMessage 하기위한 오브젝트
    public GameObject player;
    private float timer=0f;
    public GameObject effect;
    public GameObject effect1;

    // Start is called before the first frame update
    void Start()
    {
        
        playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (playerHealth <= 0)
        {
            
            //스코어 
            player.SendMessage("CompareScore");
            origin.SetActive(false);
            gameover.SetActive(true);
            

        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Monster"))// 플레이어 피격시 2.5초간 무적
        {
            //Warning UI (YW)
            attack.SetActive(true);
            warnImg.SetActive(true);
            StartCoroutine(warningUI()); //깜빡깜빢
            Invoke("AttackUIEnd", 2.5f);

            if(timer >= 2.5f)
            {
                effect = Instantiate(effect, transform.position, transform.rotation);
                effect.transform.parent = player.transform;
                effect1 = Instantiate(effect1, transform.position, transform.rotation);
                effect1.transform.parent = player.transform;
                playerHealth -= 25;
                PlayerHPbar();
                timer = 0f;
            }
            else
            {
                Debug.Log("invincibility");
            }

            
        }
    }

    IEnumerator warningUI()
    {
        int count = 0;
        while (count < 3)
        {
            warnImg.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            warnImg.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            count++;
        }
    }
    
    void AttackUIEnd()
    {
        attack.SetActive(false);
    }


    public void PlayerHPbar()
    {
        if(playerHealth == 75)
        {
            img4.sprite = img3;
        }
        else if(playerHealth == 50)
        {
            img4.sprite = img2;
        }
        else if (playerHealth == 25)
        {
            img4.sprite = img1;
        }
    }

    

}
