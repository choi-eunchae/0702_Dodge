using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //생성한 총알의 원본 프리팹

    public float spawnRateMin = 0.5f; //최소 생성 주기

    public float spawnRateMax = 3f; //최대 생성 주기

    private Transform[] targets; //발사할 대상

    private float spawnRate; //생성 주기

    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간
    

    void Start()
    {
        timeAfterSpawn = 0f; //최근 생성 이후의 누적 시간을 0으로 초기화

        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //총알 생성 간격을 spawnRateMin와 spawnRateMax 사이에서 랜덤으로 설정

               // Player1Controller, Player2Controller를 모두 찾아 타겟 배열에 저장
        var player1 = FindFirstObjectByType<PlayerController>();
        var player2 = FindFirstObjectByType<PlayerController2>();

        targets = new Transform[2];
        if (player1 != null) targets[0] = player1.transform;
        if (player2 != null) targets[1] = player2.transform;
    }


    void Update()
    {   //timeAfterSpawn을 갱신
        timeAfterSpawn += Time.deltaTime; 

        if (timeAfterSpawn >= spawnRate)  //최근 생성 시점부터 누적된 시간이 생성 주기보다 크거나 같으면
        {
            timeAfterSpawn = 0f; //누적된 시간 리셋

            // 각 타겟마다 총알을 생성하고 타겟을 바라보게 함
            foreach (var target in targets)
            {
                if (target == null) continue;
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.LookAt(target);
            }
            
            spawnRate = Random.Range(spawnRateMin, spawnRateMax); //다음번 생성 간격을 spawnRateMin와 spawnRateMax 사이에서 랜덤으로 지정
        }
        
    }
}
