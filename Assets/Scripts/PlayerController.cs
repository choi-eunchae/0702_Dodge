using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Build.Content;
using UnityEngine;



public class PlayerController : MonoBehaviour
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

        if (Input.GetKey(KeyCode.LeftArrow)) xinput = -1f;
        if (Input.GetKey(KeyCode.RightArrow)) xinput = 1f;
        if (Input.GetKey(KeyCode.UpArrow)) zinput = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) zinput = -1f;

        Vector3 newVelocity = new Vector3(xinput * speed, 0f, zinput * speed);
        playerRigidbody.linearVelocity = newVelocity;
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.EndGame();
    }
}

