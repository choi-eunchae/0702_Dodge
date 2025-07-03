using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform childTransform; // 원본 자식(씬에 붙어있는 오브젝트)
    public GameObject bulletPrefab;  // Inspector에서 연결할 총알 프리팹
    public float bulletSpeed = 15f;
    private Vector3 shootDirection = Vector3.up;

    void Start()
    {   //자신의 전역 위치를 (0, -1, 0)으로 변경
        transform.position = new Vector3(0, -1, 0);

        //자신의 지역 위치를 (0, 2, 0)으로 변경
        childTransform.localPosition = new Vector3(0, 2, 0);

        //자신의 전역 회전값을 (0, 0, 30)으로 변경
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 30));

        //자신의 지역 회전값을 (0, 60, 0)으로 변경
        childTransform.localRotation = Quaternion.Euler(new Vector3(0, 60, 0));
        
    }


    void Update()
    {
        // 방향키에 따라 발사 방향 결정 (부모의 로컬 축 기준)
            shootDirection = childTransform.up;

        // 마우스 왼쪽 클릭 시 bulletPrefab을 발사 (원본 자식은 그대로)
        if (Input.GetMouseButtonDown(0) && bulletPrefab != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, childTransform.position, childTransform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = shootDirection.normalized * bulletSpeed;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {   //위쪽 방향키를 누르면 초당 (0, 1, 0) 속도로 평행 이동
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {   //아래쪽 방향키를 누르면 초당 (0, -1, 0) 속도로 평행 이동
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {   //왼쪽 방향키를 누르면 자신을 초당 (0, 180, 0) 속도로 회전
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
            //자식 오브젝트도 같은 방향으로 회전
            childTransform.Rotate(new Vector3(0, 180, 0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {   //오른쪽 방향키를 누르면 자신을 초당 (0, 0, -180) 속도로 회전
            transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);
            //자식 오브젝트도 같은 방향으로 회전
            childTransform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
        }
    }
}
