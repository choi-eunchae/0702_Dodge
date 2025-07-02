using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xinput = 0f;
        float zinput = 0f;

        if (Input.GetKey(KeyCode.A)) xinput = -1f;
        if (Input.GetKey(KeyCode.D)) xinput = 1f;
        if (Input.GetKey(KeyCode.W)) zinput = 1f;
        if (Input.GetKey(KeyCode.S)) zinput = -1f;

        Vector3 newVelocity = new Vector3(xinput * speed, 0f, zinput * speed);
        playerRigidbody.velocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}