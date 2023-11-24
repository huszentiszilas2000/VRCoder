using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    public TMP_Text Text;

    private int[] frameRateSamples;
    private int averageFromAmount = 30;
    private int averageCounter = 0;
    private int currentAveraged;

    void Awake()
    {
        frameRateSamples = new int[averageFromAmount];
    }
    void Update()
    {
        var currentFrame = (int)Math.Round(1f / Time.smoothDeltaTime);
        frameRateSamples[averageCounter] = currentFrame;

        var average = 0f;

        foreach (var frameRate in frameRateSamples)
        {
            average += frameRate;
        }

        currentAveraged = (int)Math.Round(average / averageFromAmount);
        averageCounter = (averageCounter + 1) % averageFromAmount;

        Text.text = currentAveraged.ToString();
    }
}
