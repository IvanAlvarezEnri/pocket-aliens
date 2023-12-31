using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    public TextMeshProUGUI fpsText;

    public float pollingTime;
    private float time;
    private int frameCount;

    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate= Mathf.RoundToInt(frameCount / time);
            fpsText.text = frameRate.ToString() + "FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
