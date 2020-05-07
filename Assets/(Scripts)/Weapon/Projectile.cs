using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static bool canMove = true;
    [SerializeField] float speed;
    public int damage;
    [SerializeField] bool playerIsShooter;
    [SerializeField] bool enemyIsShooter;
    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(enemyIsShooter == true)
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(playerIsShooter == true)
        Destroy(gameObject);
    }
}
