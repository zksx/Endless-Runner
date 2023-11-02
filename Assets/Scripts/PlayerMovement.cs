using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class playermovement : MonoBehaviour
{
    Rigidbody rb;

    private float playerSpeed = 16.0f;
    private float[] playerSpeeds = { 16.0f, 32.0f, 64.0f, 128.0f };
    public float targetTime = 10.0f;
    private int speed_index = 0;
    private int set_speeds;
    private float gravity_force = -9.8f;

    public float x_input;
    public float x_speed = 40f;

    private void Start()
    {
        //Fetch the Rigidbody from the GameObject with this   script attached
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
      Move();
    }

    private void Move()
    {

        if ((targetTime < 0f) && (set_speeds - 1 > speed_index))
        {

            playerSpeed = playerSpeeds[speed_index];
            speed_index += 1;
            targetTime = 10.0f;
        }

        x_input = Input.GetAxis("Horizontal") * x_speed;

        Vector3 m_Input = new Vector3(x_input, gravity_force, playerSpeed);

        rb.AddForce(m_Input);

    }

}
