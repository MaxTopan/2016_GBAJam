using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PxScale : MonoBehaviour
{
    public int vertPixels = 144;
    public bool cropPref = true;
    private float screenYPixels = 0;
    private bool currentCropped = false;

    // Update is called once per frame
    void Update()
    {
        if (screenYPixels != (float)Screen.height || currentCropped != cropPref)
        {
            screenYPixels = (float)Screen.height;
            currentCropped = cropPref;

            float screenRatio = screenYPixels / vertPixels;
            float ratio;

            if (cropPref)
            {
                ratio = Mathf.Floor(screenRatio) / screenRatio;
            }
            else
            {
                ratio = Mathf.Ceil(screenRatio) / screenRatio;
            }

            transform.localScale = Vector3.one * ratio;
        }
    }
}
