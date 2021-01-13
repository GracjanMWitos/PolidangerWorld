using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public abstract class EnemyAI : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] public GameObject player;
    [SerializeField] public float distanceToSeePlayer = 4;
    [SerializeField] public float speed = 2;
    public int damage;
    public double distanceToKeepFromPlayer = 3f;
    public double distanceToMeleeAttack;
    public Rigidbody2D bullet;
    private Vector3 target;
    private Transform operationCenter;
    [SerializeField] private float timer;
    public double timeToNextAttack;
    public int xp; // xp that enemy left after death

    public void Awake()
    {
        operationCenter = GameObject.Find("OperationCenter").GetComponent<Transform>();
        gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
    }
    public virtual void Update()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform.position;
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (Vector2.Distance(transform.position, player.transform.position) <= distanceToMeleeAttack)
            FirstActivity();
        if (Vector2.Distance(transform.position, player.transform.position) < distanceToSeePlayer && Vector2.Distance(transform.position, player.transform.position) > distanceToKeepFromPlayer)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, player.transform.position) <= distanceToSeePlayer)
        {
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            SecondActivity();
        }
        
    }
    public virtual void SecondActivity()
    {

    }
    public virtual void FirstActivity()
    {

    }
    void Death()
    {
        gameManager.enemyLeft -= 1;
        gameManager.xp += gameManager.xp_multipilier * xp;
        Destroy(gameObject);
    }
    void TakeDamages()
    {
        if(timer <= 0)
        player.GetComponent<PlayerController>().currentHealthPoints -= (int)damage;
        timer = (float)timeToNextAttack;
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
        public override void SecondActivity()
        {
            Instantiate(bullet, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }
        public override void FirstActivity()
        {
            TakeDamages();
        }
    }
}

