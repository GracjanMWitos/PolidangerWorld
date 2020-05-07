using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nightmare_AI : MonoBehaviour
{
private Transform playerPos;
    public float speed;
    Rigidbody2D rb;
    [SerializeField] string spawner_name;
    private EnemySpawner spawner;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        spawner = GameObject.Find(spawner_name).GetComponent<EnemySpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            spawner.enemyLeft -= 1;
        }
    }
}
