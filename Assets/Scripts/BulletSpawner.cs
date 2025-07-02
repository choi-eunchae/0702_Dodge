using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; //생성한 총알의 원본 프리팹

    public float spawnRateMin = 0.5f; //최소 생성 주기

    public float spawnRateMax = 3f; //최대 생성 주기

    private Transform target; //발사할 대상

    private float spawnRate; //생성 주기

    private float timeAfterSpawn; //최근 생성 시점에서 지난 시간

    private AudioSource spawnSound; //오디오 소스 컴포넌트

    public AudioClip spawnClip; //총알 생성 시 재생할 오디오 클립

    void Start()
    {
        timeAfterSpawn = 0f; //최근 생성 이후의 누적 시간을 0으로 초기화

        spawnRate = Random.Range(spawnRateMin, spawnRateMax); //총알 생성 간격을 spawnRateMin와 spawnRateMax 사이에서 랜덤으로 설정

        target = FindFirstObjectByType<PlayerController>().transform; //PlayerController 컴포넌트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정  

        spawnSound = GetComponent<AudioSource>(); //현재 게임 오브젝트에 부착된 AudioSource 컴포넌트를 가져옴
    }



    void Update()
    {   //timeAfterSpawn을 갱신
        timeAfterSpawn += Time.deltaTime; 

        if (timeAfterSpawn >= spawnRate)  //최근 생성 시점부터 누적된 시간이 생성 주기보다 크거나 같으면
        {
            spawnSound.PlayOneShot(spawnClip); //총알 생성 사운드 재생
            timeAfterSpawn = 0f; //누적된 시간 리셋

            //transform.position 위치와 transform.rotation 회전값을 가진 bulletPrefab의 복제본을 생성하여 bullet 변수에 할당
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation); 

            bullet.transform.LookAt(target); //생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            
            spawnRate = Random.Range(spawnRateMin, spawnRateMax); //다음번 생성 간격을 spawnRateMin와 spawnRateMax 사이에서 랜덤으로 지정
        }
        
    }
}
