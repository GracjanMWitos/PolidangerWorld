using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAI : MonoBehaviour
{
    private Vector3 target;
    private Transform operationCenter;
    private Transform playerPos;

    public Transform gun;
    public Rigidbody2D bullet;
    public AudioClip gunShot;
    public AudioSource Sound;
    [SerializeField] private float timer;

    public float timerAtStart;
    public float timeToNextShot;
    public Animator anim;
    [Header("OneBarrels")]
    public bool confirm1;
    [Header("TwoBarrels")]
    public bool confirm2;
    [SerializeField] private bool oneOfTwoBarrel;
    [SerializeField] private bool twoOfTwoBarrel;
    [Header("ThreeBarrels")]
    public bool confirm3;
    [SerializeField] bool oneOfThreeBarrel;
    [SerializeField] bool twoOfThreeBarrel;
    [SerializeField] bool threeOfThreeBarrel;
    private void Start()
    {
        operationCenter = GameObject.Find("OperationCenter").GetComponent<Transform>();
        anim = GetComponent<Animator>();
        anim.SetBool("isShoting1", false);
        anim.SetBool("isShoting2", false);

        timer = timerAtStart;
    }
    void Update()
    {
        Vector3 dir = target - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (confirm1 && Vector2.Distance(transform.position, target) < 10)
        {
            Is1();
        }
        if (confirm2 && Vector2.Distance(transform.position, target) < 10)
        {
            Is2();
        }
        if (confirm3 && Vector2.Distance(transform.position, target) < 10)
        {
            Is3();
        }
    }
    private void FixedUpdate()
    {

    }
    void Is1()
    {
        if (timer > 0)
        {
            anim.SetBool("isShoting", false);
            anim.SetBool("isIdle", true);
            timer -= Time.deltaTime;
        }
        else if (timer <= 0)
        {
            anim.SetBool("isShoting", true);
            anim.SetBool("isIdle", false);
            timer = timeToNextShot;
            Rigidbody2D bulletClone = Instantiate(bullet, gun.position, gun.rotation);
        }
    }
    void Is2()
    {
        if (twoOfTwoBarrel)
            if (timer > 0)
            {
                anim.SetBool("isShoting1", false);
                anim.SetBool("isShoting2", false);
                anim.SetBool("IsIdle", true);
                timer -= Time.deltaTime;
            }
            else if (timer <= 0)
            {
                anim.SetBool("isShoting1", false);
                anim.SetBool("isShoting2", true);
                anim.SetBool("isIdle", false);
                timer = timeToNextShot;
                Rigidbody2D bulletClone = Instantiate(bullet, gun.position, gun.rotation);
            }
        if (oneOfTwoBarrel)
            if (timer > 0)
            {
                anim.SetBool("isShoting1", false);
                anim.SetBool("isShoting2", false);
                anim.SetBool("isIdle", true);
                timer -= Time.deltaTime;
            }
            else if (timer <= 0)
            {
                anim.SetBool("isShoting2", false);
                anim.SetBool("isShoting1", true);
                anim.SetBool("isIdle", false);
                timer = timeToNextShot;
                Rigidbody2D bulletClone = Instantiate(bullet, gun.position, gun.rotation);
            }
    }
    void Is3()
    {
        if (timer > 0)
        {
            anim.SetBool("isShoting1", false);
            anim.SetBool("isShoting2", false);
            anim.SetBool("isIdle", true);
            timer -= Time.deltaTime;
        }
        else if (timer <= 4)
        {
            anim.SetBool("isShoting2", true);
            anim.SetBool("isShoting1", false);
            anim.SetBool("isIdle", false);
            Rigidbody2D bulletClone = Instantiate(bullet, gun.position, gun.rotation);
        }
        else if (timer <= 0)
        {
            anim.SetBool("isShoting2", false);
            anim.SetBool("isShoting1", true);
            anim.SetBool("isIdle", false);
            timer = 8;
            Rigidbody2D bulletClone = Instantiate(bullet, gun.position, gun.rotation);
        }
    }
}