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
    float playerRotation;
    void Start()
    {
        playerRotation = GameObject.FindGameObjectWithTag("Player").transform.rotation.z;
        scattering = Random.Range(-scattering,scattering);
    }
    void Update()
    {
        transform.Translate(scattering, 1 * speed * Time.deltaTime, 0);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("Enemy"))
        Destroy(gameObject);
    }
}
