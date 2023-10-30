using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {

        print(collision.tag);

        if (collision.CompareTag("Obstacle"))
        {
            print("we got a hit");
        }
    }
}
