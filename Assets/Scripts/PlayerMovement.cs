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
    private float gravity_force = -1f;

    public float x_input;
    public float x_speed = 40f;
    public float speed = 1f;

    public Vector3 updatedVelocity;

    public static GameObject ballObject;

    private void Start()
    {
        //Fetch the Rigidbody from the GameObject with this   script attached
        ballObject = GameObject.Find("Player");
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
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), gravity_force, speed);
        rb.MovePosition(transform.position + input * Time.deltaTime * speed);
    }
}
