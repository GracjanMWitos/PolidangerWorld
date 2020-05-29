using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Nightmare_AI : MonoBehaviour
{
private Transform playerPos;
    [SerializeField] float speed;
    [SerializeField] float timeToMaxSpeed;
    Rigidbody2D rb;
    private ScoreMenager scoreMenager;
    private Vector3 target;
    private Transform operationCenter;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        scoreMenager = GameObject.Find("Menagers").GetComponent<ScoreMenager>();
        operationCenter = GameObject.Find("OperationCenter").GetComponent<Transform>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       TargetChange();
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        


        //rb.velocity = Vector2.MoveTowards(rb.velocity, target.transform.position,timeToMaxSpeed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    void TargetChange()
    {
        if(Vector2.Distance(transform.position,playerPos.position) > Vector2.Distance(transform.position, operationCenter.transform.position))
            {
            target = operationCenter.transform.position;
            }
        else if (Vector2.Distance(transform.position, playerPos.position) < Vector2.Distance(transform.position, operationCenter.transform.position))
        {
            target = playerPos.position;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.collider.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            scoreMenager.enemyLeft -= 1;
        }
    }
}
