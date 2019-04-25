using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    public float cameraSpeed = 1.0f;
    public float bulletSpeed = 1.0f;
    Vector3 movement = Vector3.zero;


    // Use this for initialization
    void Start()
    {
        movement.x = (cameraSpeed/10);
        if (gameObject.tag == "Bullet")
            movement.x += (bulletSpeed/10);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += movement;
    }
}
