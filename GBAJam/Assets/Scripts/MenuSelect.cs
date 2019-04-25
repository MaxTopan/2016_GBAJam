using UnityEngine;
using System.Collections;

public class MenuSelect : MonoBehaviour
{
    public int level;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Bullet" || other.transform.tag == "Player")
        {
            Application.LoadLevel(level);
        }
    }
}
