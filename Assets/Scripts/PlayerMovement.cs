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

    public Vector3 updatedVelocity;

    public static GameObject ballObject;

    private void Start()
    {
        //Fetch the Rigidbody from the GameObject with this   script attached
        ballObject = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        updatedVelocity = new Vector3(0f, -9.81f, 0f);
    }

    private void Update()
    {
        if(Input.GetKeyDown("left"))
        {
            updatedVelocity.x -= 10f;
        }
        else if(Input.GetKeyDown("right"))
        {
            updatedVelocity.x += 10f;
        }
    }

    private void FixedUpdate()
    {
      Move();
    }

    private void Move()
    {
        // TODO: Implement a system that will incrementally increase the speed
        //if ((targetTime < 0f) && (set_speeds - 1 > speed_index))
        //{

        //    playerSpeed = playerSpeeds[speed_index];
        //    speed_index += 1;
        //    targetTime = 10.0f;
        //}

        if(updatedVelocity.z < 50f)
        {
            updatedVelocity.z += .25f;
        }

        rb.velocity = updatedVelocity;
    }
}
