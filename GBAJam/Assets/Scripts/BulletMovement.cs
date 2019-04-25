using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Boundary")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().bulFired += 1; // false;   //When the bullet hits a collider it will set the bool in the player to false so the player can shoot again
    }
}