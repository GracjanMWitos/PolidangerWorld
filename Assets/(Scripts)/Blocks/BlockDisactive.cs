using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDisactive : MonoBehaviour
{
    public bool isTouchingPower;
    public GameObject blockToDisactive;
    public AudioClip powerSound;
    private AudioSource audioSource;
    public Transform playerPos;
    private Rigidbody2D rb;
    public int score;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isTouchingPower && Input.GetKeyDown(KeyCode.E))
        {
            blockToDisactive.SetActive(true);
            gameObject.SetActive(false);

        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isTouchingPower = true;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            isTouchingPower = false;
        }
    }
}
