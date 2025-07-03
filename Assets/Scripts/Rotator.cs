using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float minSpeed = -180f;
    public float maxSpeed = 180f;
    public float changeInterval = 1.0f; // 방향이 바뀌는 시간 간격(초)

    private float rotationSpeed;
    private float timer;

    void Start()
    {
        rotationSpeed = Random.Range(minSpeed, maxSpeed);
        timer = 0f;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            rotationSpeed = Random.Range(minSpeed, maxSpeed);
            timer = 0f;
        }
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}