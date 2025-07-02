using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; //총알 이동 속력
    private Rigidbody bulletRigidbody; //이동에 사용할 리지드바디 컴포넌트

    void Start()
    {   //게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody 변수에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //Rigidbody의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.linearVelocity = transform.forward * speed;

        //3초 후에 자신의 게임 오브젝트를 파괴
        Destroy(gameObject, 3f);
    }

    // 트리거 충돌시 자동으로 실행되는 메서드
    void OnTriggerEnter(Collider other){
        //충돌한 상대방 게임 오브젝트가 "Player" 태그를 가진 경우
        if (other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 Player_controler 컴포넌트를 찾아 player_Controler 변수에 할당
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대방으로부터 Player_controler 컴포넌트를 찾았으면
            if (playerController != null)
            {
                //상대방 Player_controler 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
