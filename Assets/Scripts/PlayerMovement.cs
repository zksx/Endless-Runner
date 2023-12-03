using UnityEngine;
using TMPro;

public class playermovement : MonoBehaviour
{
    Rigidbody rb;

    public float targetTime = 10.0f;
    private float gravity_force = -0.005f;
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
        scoreText.text = "Score: " + score;
        currentSpeed.text = "Speed: " + speed;
    }

    private void Move()
    {

        int expectedSpeedIncreaseCount = Mathf.FloorToInt(score / 200);

        if(expectedSpeedIncreaseCount > speedIncreaseCount)
        {
            speedIncreaseCount = expectedSpeedIncreaseCount;
        }

        if( speed < maxSpeed )
        {
            speed = baseSpeed + speedIncreaseCount;
        }

        float xInput = Input.GetAxis("Horizontal");
        Vector3 input = new Vector3(xInput, gravity_force, 1f);
        Vector3 direction = transform.position + input * Time.deltaTime * speed;

        // Smooth transition for direction change
        transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * turnSpeed);
    }
}
