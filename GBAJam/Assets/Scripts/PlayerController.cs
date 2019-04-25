using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;

    float localY = 1.39f;                                                       //Float for adding/taking away height
    //public bool bulFired;                                                       //If a bullet is still on screen 
    public int bulFired = 3;

    void Update()
    {
        GetInput();                                                             //Searches for input each frame
        Debug.Log(bulFired);
    }

    void GetInput()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.X))                                            //If left mouse button is clicked
        {
            if (bulFired > 0)                                                      //If there is no bullet on screen
            {
                Fire();                                                         //Call the fire button to instantiate a bullet
                bulFired -= 1; // = true;                                                //Set the bool 
            }
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))                             //If up is pressed then move the object up 1.39 UnityUnits (UU)
        {
            if (transform.position.y < 0.90f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + localY, transform.position.z);
            }
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))                           //If down is pressed then down 1.39 UU
        {
            if (transform.position.y > -3.15f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - localY, transform.position.z);
            }
        }
    }

    void Fire()
    {
        Vector3 pos = transform.position;
        pos.x += 0.5f;
        Instantiate(bullet, pos, Quaternion.identity);           //Make a bullet
    }
}