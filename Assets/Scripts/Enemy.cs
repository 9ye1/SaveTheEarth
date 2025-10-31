using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform[]  WayPoints;
    NavMeshAgent nav;
    Animator animator;
    private Transform playerTransform;

    private Transform thisTransform;
    
    public int r;
    public float attackRange;
    protected float distance;//
    private bool canAtk = true;
    private int nextIdx;

    void Start()
    {
        WayPoints = GameObject.Find("EnemyWayPoints").GetComponentsInChildren<Transform>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        thisTransform = GetComponent<Transform>();
        nextIdx = UnityEngine.Random.Range(0, WayPoints.Length);

    }
    

    void Update()
    {
        //player와 enemy의 거리가 2 이하이면, 이동목표 : 플레이어위치
        if (r > Vector3.Distance(thisTransform.position, playerTransform.position))
        {
            nav.SetDestination(playerTransform.position);
            animator.SetBool("IsRun", true);
            if (CanAtkStateFun())//플레이어 공격가능 상태면 공격애니메이션
            {
                animator.SetTrigger("Attack");
                canAtk = false;
                StartCoroutine(WaitForIt());
            }
            
        }
        
        else
        {  //player와 enemy의 거리가 r 이상이면, 랜덤한 곳을 번갈아가며 순찰
           
            if (Vector3.Distance(thisTransform.position, nav.destination) <= nav.stoppingDistance+2)
            {
                    nextIdx = UnityEngine.Random.Range(0, WayPoints.Length);
                    nav.destination = WayPoints[nextIdx].position;
            }
            else
            {
                nav.destination = WayPoints[nextIdx].position;
            }
           
            animator.SetBool("IsRun", false);
        }
    }

  

    protected bool CanAtkStateFun()//몬스터가 플레이어  공격 가능 판단 
    {
       distance = Vector3.Distance(playerTransform.position, transform.position);

        if ( distance <= attackRange && canAtk)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator WaitForIt()// 공격애니메이션 한번만 실행되게 지연
    {
        yield return new WaitForSeconds(2.0f);
        canAtk = true;
    }
    

}
