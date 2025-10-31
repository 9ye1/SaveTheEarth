using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    Animator anim;
    public float r;
    private float enemyHealth;
    public GameObject explosion;

    //ScoreScript 에 SendMessage 하기위한 오브젝트
    private GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        enemyHealth = r;
    }
    

    void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            player.SendMessage("MonsterScore", 15);
        }
    }


    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Bullet"))
        {
            enemyHealth -= 20;
        }
    }

    



}
