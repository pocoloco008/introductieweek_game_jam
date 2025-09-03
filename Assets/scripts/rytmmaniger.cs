using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class rytmmaniger : MonoBehaviour
{
    public static int Wpressed = 0;
    public static int Spressed = 0;
    public static int Apressed = 0;
    public static int Dpressed = 0;
    public static int lives = 10;
    public static int points = 0;
    public float time;
    private bool timed = false;

    // List of all timing points (one beat per second)
    private List<float> timingPoints = new List<float>
    {
        1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f, 10.0f,
        11.0f, 12.0f, 13.0f, 14.0f, 15.0f, 16.0f, 17.0f, 18.0f, 19.0f, 20.0f,
        21.0f, 22.0f, 23.0f, 24.0f, 25.0f, 26.0f, 27.0f, 28.0f, 29.0f
    };

    // Track which timing points we've already processed
    private List<float> processedPoints = new List<float>();

    public float hitWindow = 0.5f;

    void Start()
    {
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;

        foreach (float timePoint in timingPoints)
        {
            if (!processedPoints.Contains(timePoint) &&
                time >= timePoint &&
                time <= timePoint + hitWindow)
            {
                StartCoroutine(CheckButtonPress(timePoint));
                processedPoints.Add(timePoint);
            }
        }

        if (lives == 0)
        {
            // Switch scene
        }

        // Reset button presses if they weren't used in a timing check
        ResetUnusedButtonPresses();
    }

    IEnumerator CheckButtonPress(float timePoint)
    {
        timed = true;
        Debug.Log("press W");
        // Display the need for the press

        yield return new WaitForSeconds(hitWindow);

        if (Wpressed == 0)
        {
            lives -= 1;
            // Play miss sound
        }
        else
        {
            Wpressed = 0;
            points += 1;
            Debug.Log("Hit! Points: " + points);
        }

        timed = false;
    }

    private void ResetUnusedButtonPresses()
    {
        if (!timed)
        {
            if (Wpressed == 1) Wpressed = 0;
            if (Spressed == 1) Spressed = 0;
            if (Apressed == 1) Apressed = 0;
            if (Dpressed == 1) Dpressed = 0;
        }
    }

  
}