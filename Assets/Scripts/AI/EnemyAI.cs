using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public abstract class EnemyAI : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] public Transform playerPos;
    [SerializeField] public float distanceToSeePlayer = 4;
    [SerializeField] public float speed = 2;

    public double distanceToKeepFromPlayer = 3f;
    public Rigidbody2D bullet;
    private Vector3 target;
    private Transform operationCenter;
    [SerializeField] private float timer;
    public int xp; // xp that enemy left after death

    public void Awake()
    {
        operationCenter = GameObject.Find("OperationCenter").GetComponent<Transform>();
        gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
    }
    public virtual void FixedUpdate()
    {
        if(playerPos == null)
            playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        target = playerPos.position;
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (Vector2.Distance(transform.position, playerPos.position) < distanceToSeePlayer && Vector2.Distance(transform.position, playerPos.position) > distanceToKeepFromPlayer)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, playerPos.position) <= distanceToSeePlayer)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            DoSomething();
        }
        
    }
    public virtual void DoSomething()
    {

    }
    void Death()
    {
        gameManager.enemyLeft -= 1;
        gameManager.xp += gameManager.xp_multipilier * xp;
        Destroy(gameObject);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.CompareTag("Bullet"))
        {
            Death();
        }
    }
    public abstract class ShootingEnemy : EnemyAI
    {
        public override void DoSomething()
        {
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }
    }
}

