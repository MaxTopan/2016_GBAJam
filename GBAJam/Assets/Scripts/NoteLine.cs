using UnityEngine;
using System.Collections;

public class NoteLine : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Note")
        {
            StartCoroutine(other.gameObject.GetComponent<NoteControl>().DeathTrigger());
        }
        else if (other.transform.tag == "EndCollider")
        {
            other.gameObject.GetComponent<Percentage>().CalculatePercentage();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Note")
        {
            //StartCoroutine(other.gameObject.GetComponent<NoteControl>().DeathTrigger());
            // Take health away from the player
        }
    }
}
