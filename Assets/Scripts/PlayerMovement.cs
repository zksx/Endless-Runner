using UnityEngine;
using TMPro;

public class playermovement : MonoBehaviour
{
    Rigidbody rb;

    public float targetTime = 10.0f;
    private float gravity_force = -0.2f;
    public float turnSpeed = 40f;

    public float x_input;
    private int speedIncreaseCount = 0;
    private float baseSpeed = 12f;
    private int score = 0;
    public float speed = 12f;
    private float maxSpeed = 25f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI currentSpeed;

    public static GameObject ballObject;

    private void Start()
    {
        ballObject = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
        score = Mathf.RoundToInt(transform.position.z);
        GameData.Score = score;
        scoreText.text = "Score: " + score;
        currentSpeed.text = "Speed: " + speed;
    }

    private void Move()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        int expectedSpeedIncreaseCount = Mathf.FloorToInt(score / 200);

        if(expectedSpeedIncreaseCount > speedIncreaseCount)
        {
            speedIncreaseCount = expectedSpeedIncreaseCount;
        }

        if( speed < maxSpeed )
        {
            speed = baseSpeed + speedIncreaseCount;
        }

        Vector3 moveDirection = new Vector3(xInput, gravity_force, 1f);

        Vector3 targetVelocity = moveDirection * speed;

        rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, turnSpeed * Time.fixedDeltaTime);
    }
}
