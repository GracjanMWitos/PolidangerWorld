using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    public int damage;
    [SerializeField] bool playerIsShooter;
    [SerializeField] bool enemyIsShooter;
    public float scattering;
    void Start()
    {

    }
    void Update()
    {
        float a;
        transform.Translate(a = Random.Range(-scattering, scattering),1,0);
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
