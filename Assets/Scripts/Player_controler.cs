using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player_controler : MonoBehaviour
{
    public Rigidbody playerRigidbody; 
    public float speed = 8f; 

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) == true)
        {
            // Log a message to the console when the up arrow key is pressed
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            // Log a message to the console when the down arrow key is pressed
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            // Log a message to the console when the right arrow key is pressed
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            // Log a message to the console when the left arrow key is pressed
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }

    }
}
