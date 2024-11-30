using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BalloonController : MonoBehaviour
{
    public AudioClip popSound;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(popSound);
            GameManager.instance.ReloadSceneGame();
            Destroy(gameObject);
        }
    }
}
