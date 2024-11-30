using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{
    public GameObject balloon;
    public AudioSource audioSource;
    
    private Vector2 mousePosition;
    private Vector2 balloonPosition;

    private void Update()
    {
        if(balloon != null)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            balloonPosition = balloon.transform.position;

            Vector2 dir = (mousePosition - balloonPosition).normalized;
            float distance = Vector2.Distance(mousePosition, balloonPosition);

            if(distance <= 3)
            {
                float multiplier = 4 / distance;
                balloon.GetComponent<Rigidbody2D>().velocity = -(dir * multiplier);
            }
        }
    }
}
