using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {

        print(collision.tag);

        if (collision.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.CompareTag("FallGround"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
