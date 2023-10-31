using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 4.0f;
    private float[] playerSpeeds = {4.0f, 8.0f, 16.0f, 32.0f};
    private float gravityValue = -9.81f;
    public float targetTime = 10.0f;
    private int speed_index = 0;
    private int set_speeds;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        set_speeds = playerSpeeds.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        groundedPlayer = controller.isGrounded;

        if ((targetTime < 0f) && (set_speeds - 1 > speed_index))
        {
            playerSpeed = playerSpeeds[speed_index];
            speed_index += 1;
            targetTime = 10.0f;
        }

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new(Input.GetAxis("Horizontal"), 0, playerSpeed);
        controller.Move(playerSpeed * Time.deltaTime * move);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        targetTime -= Time.deltaTime;

    }
}