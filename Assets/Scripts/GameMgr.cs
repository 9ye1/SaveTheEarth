using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{

    //points는 배열로 담을 수 있도록 한다.
    public Transform[] points;
    public GameObject[] monster;
    // 3초마다 몬스터를 만든다.
    public float createTime = 3.0f;
    public int MaxMonster = 100;
    private int currentMS = 0;


    // Use this for initialization
    void Start()
    {
        // points를 게임시작과 함께 배열에 담기
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();
        StartCoroutine(this.CreateMonster());
    }

    IEnumerator CreateMonster()
    {
        // 계속해서 createTime동안 monster생성
        while (currentMS <= MaxMonster)
        {
            int idx = UnityEngine.Random.Range(0, points.Length);
            int midx = UnityEngine.Random.Range(0, monster.Length);
            Instantiate(monster[midx], points[idx].position, Quaternion.identity);
            currentMS++;

            yield return new WaitForSeconds(createTime);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
 
 
 

