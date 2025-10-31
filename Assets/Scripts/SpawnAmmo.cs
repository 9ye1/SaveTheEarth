using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnAmmo : MonoBehaviour
{
    public GameObject Ammo;
    private BoxCollider area;
    public int count = 100;

    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>();
        for (int i = 0; i < count; i++)
        {
            Spawn();
        }
        StartCoroutine(this.CreateAmmo());
    }

    private void Spawn()
    {
        Vector3 spawnPos = GetRandomPosition();
        Ammo = Instantiate(Ammo, spawnPos, Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size; // 박스 콜라이더의 사이즈

        float posX = basePosition.x + UnityEngine.Random.Range(-size.x / 2f, size.x / 2f);
        // 미니멈과 맥시멈 값을 정해주면 알아서 그 범위 내에서 랜덤을 부여한다.
        float posY = basePosition.y + UnityEngine.Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + UnityEngine.Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);
        // 위의 벡터 포지션을 한 변수로 묶어주기

        return spawnPos; // 이 묶어준 변수를 밖으로 빼내기

    }
    IEnumerator CreateAmmo()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(5f);
        }
    }
        

// Update is called once per frame
void Update()
    {
        
    }
}
