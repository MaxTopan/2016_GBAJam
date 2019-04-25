using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Percentage : MonoBehaviour
{
    public Text disp;
    private float num;
    private float den;

    // Use this for initialization
    void Start()
    {
        den = GameObject.FindGameObjectsWithTag("Note").Length;
        disp.text = "";
    }

    public void CalculatePercentage()
    {
        num = GameObject.FindGameObjectsWithTag("Note").Length;
        float result = 100 - ((num / den) * 100);
        disp.text = result.ToString("#") + "%";
    }
}
