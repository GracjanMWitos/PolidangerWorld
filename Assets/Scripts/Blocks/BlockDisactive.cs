using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDisactive : MonoBehaviour
{
    public bool isTouching;
    public AudioClip powerSound;
    private AudioSource audioSource;
    [SerializeField] GameObject buttonSprite;
    private ScoreMenager scores;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        scores = GameObject.Find("Menagers").GetComponent<ScoreMenager>();
    }
    private void Update()
    {
        if (isTouching && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(this.gameObject);
            scores.switchesTurnedOn += 1;
        }
        buttonSprite.SetActive(isTouching);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouching = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouching = false;
            
        }
    }
}
