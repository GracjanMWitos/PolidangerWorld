using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Nightmare_AI : MonoBehaviour
{
private Transform playerPos;
    [SerializeField] private float speed;
    private ScoreMenager scoreMenager;
    private Vector3 target;
    private Transform operationCenter;
    [SerializeField] private float distanceToChangeTarget;
    [SerializeField] float timer;
    [SerializeField] PauseScript pause;
    void Start()
    {
        scoreMenager = GameObject.Find("Menagers").GetComponent<ScoreMenager>();
        operationCenter = GameObject.Find("OperationCenter").GetComponent<Transform>();
        pause = GameObject.Find("Menagers").GetComponent<PauseScript>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        TargetChange();
    }
    void TargetChange()
    {
        if (pause.characterMenuOn || playerPos == null)
            target = operationCenter.transform.position;
        if (pause.characterMenuOn == false || playerPos != null)
        {
            playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            if (Vector2.Distance(transform.position, playerPos.position) * distanceToChangeTarget > Vector2.Distance(transform.position, operationCenter.transform.position))
                target = operationCenter.transform.position;
            else if (Vector2.Distance(transform.position, playerPos.position) * distanceToChangeTarget < Vector2.Distance(transform.position, operationCenter.transform.position))
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
