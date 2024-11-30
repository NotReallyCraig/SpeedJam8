using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public GameObject balloon;
    public AudioSource audioSource;
    public float strength;
    public float dist;
    public float accelerationMultiplier = 1.0f; // A multiplier to control acceleration

    private Vector2 mousePosition;
    private Vector2 balloonPosition;

    private Rigidbody2D rb;

    private void Start()
    {
        // Cache the Rigidbody2D to avoid repeated GetComponent calls
        if (balloon != null)
        {
            rb = balloon.GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        if (balloon != null && rb != null)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            balloonPosition = balloon.transform.position;

            Vector2 dir = (mousePosition - balloonPosition).normalized;
            float distance = Vector2.Distance(mousePosition, balloonPosition);

            // Calculate acceleration based on strength and distance
            float acceleration = (accelerationMultiplier * strength) / (distance / 2);

            // Only apply force if the left mouse button is pressed
            if (Input.GetMouseButton(0)) // 0 is for the left mouse button
            {
                // Apply the acceleration force in the opposite direction of the mouse
                if (distance <= dist)
                {
                    rb.AddForce(-(dir * acceleration));
                }
            }
        }
    }
}
