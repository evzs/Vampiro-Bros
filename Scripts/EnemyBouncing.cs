using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBouncing : MonoBehaviour
{
    [SerializeField] private float bounce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AudioClip bounceSound;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Bounceable")
        {
            audioSource.PlayOneShot(bounceSound);
            collider.gameObject.SetActive(false);
            rb.velocity = new Vector2(rb.velocity.x, bounce);
        }
    }
}