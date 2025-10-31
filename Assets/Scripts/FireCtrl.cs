using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using UnityEngine.UI;

public class FireCtrl : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public int MaxMagazine = 100;
    private int magazine;
    private bool empty;
    public int ShootCoolTime= 350;
    private static int Cool;

    [SerializeField] Text bullettext;

    private static bool isShootEnable;
    private Thread thread_shoot;

    // Start is called before the first frame update
    void Start()
    {
        magazine = MaxMagazine;
        Cool = ShootCoolTime;
        empty = false;
        isShootEnable = true;
        thread_shoot = new Thread(new ThreadStart(ThreadList));
        thread_shoot.Start();
    }

    // Update is called once per frame
    void Update()
    {
        bullettext.text = ""+ magazine;
        if (isShootEnable && empty == false)
        {
            Fire();
            isShootEnable = false;
            if (magazine>0)
            {
                magazine -= 1;
            }
            else { 
                magazine = 0;
                empty = true;
            }
        }
        if (magazine >0)
        {
            empty = false;
        }
        
    }

    void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
       
    }

    private static void ThreadList()
    {
        while (true)
        {
            if (!isShootEnable)
            {
                Thread.Sleep(Cool);      //0.2초(200밀리초)
                isShootEnable = true;
            }
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "Item")
        {
            if (magazine >= MaxMagazine)
            {
                magazine = MaxMagazine;
            }
            else
            {
                if (magazine >=MaxMagazine - 30)
                {
                    magazine = MaxMagazine;
                    Destroy(coll.gameObject);
                }
                else
                {
                    magazine += 30;
                    Destroy(coll.gameObject);
                }
            }
        }
    }

}
