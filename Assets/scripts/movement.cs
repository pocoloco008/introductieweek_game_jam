using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    // Reference to the Keyboard device
    private Keyboard keyboard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the keyboard device
        keyboard = Keyboard.current;

        if (keyboard == null)
        {
            Debug.LogError("No keyboard detected!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard == null) return;

        // Check for key presses with the new Input System
        if (keyboard.wKey.wasPressedThisFrame)
        {
            rytmmaniger.Wpressed = 1;
        }

        if (keyboard.sKey.wasPressedThisFrame)
        {
            rytmmaniger.Spressed = 1;
        }

        if (keyboard.aKey.wasPressedThisFrame)
        {
            rytmmaniger.Apressed = 1;
        }

        if (keyboard.dKey.wasPressedThisFrame)
        {
            rytmmaniger.Dpressed = 1;
        }
    }
}