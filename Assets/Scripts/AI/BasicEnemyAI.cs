using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public abstract class BasicEnemyAI : MonoBehaviour
{
    GameManager gameManager;
    Animator animator;
    public AIPath aiPath;
    [SerializeField] public float distanceToSeePlayer = 4;
    [SerializeField] public float speed = 2;
    private bool playerGetsDamages;
    private int hp;
    public int xp; // xp that enemy left after death
    private Animator damageAnim;
    public void Awake()
    {
        gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
        aiPath = GetComponent<AIPath>();
        animator = GetComponent<Animator>();
        damageAnim = GameObject.Find("DamageImage").GetComponent<Animator>();
    }
    public virtual void Update()
    {
        if(aiPath.reachedEndOfPath)
        {
            //Attack();
        }
        if (aiPath.remainingDistance >= distanceToSeePlayer)
        {
            aiPath.canMove = false;
            Debug.Log(aiPath.canMove);
        }
        else
        {
            aiPath.canMove = true;
        }
    }
    public virtual void Attack(){
        animator.SetTrigger("Attack");
    }
    void Death()
    {
        gameManager.enemyLeft -= 1;
        gameManager.xp += gameManager.xp_multipilier * xp;
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player"))
        {
            damageAnim.SetTrigger("Starting");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            damageAnim.SetTrigger("Fading");
        }
    }
}

