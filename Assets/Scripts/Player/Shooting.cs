using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour    
{
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
        anim.SetBool("isShoting1", false);
        anim.SetBool("isShoting2", false);

        timer = timerAtStart;
    }
    void Update()
    {

        if (confirm1 )
        {
            Is1();
        }
        if (confirm2)
        {
            Is2();
        }
        if (confirm3)
        {
            Is3();
        }
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
            else if (timer <=0)
            {
                anim.SetBool("isShoting1", false);
                anim.SetBool("isShoting2", true);
                anim.SetBool("isIdle", false);
                timer = timeToNextShot;
                Rigidbody2D bulletClone = Instantiate(bullet, gun.position, gun.rotation);
            }
        if(oneOfTwoBarrel)
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
