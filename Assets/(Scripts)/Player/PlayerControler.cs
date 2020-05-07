using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float playerSpeed;
    [SerializeField] Transform OCPos;

    private Rigidbody2D rb;
    Vector2 movement;
    Vector2 target;
    private Animator anim;
    [Header("Interaction")]
    public GameObject ballMode;
    public GameObject player;
    public PaddleMovement paddleMovement;
    public Transform playerPosition;
    [Header("Abilitis")]
    public Transform gun;
    public Rigidbody2D bullet;
    public AudioClip gunShot;
    public AudioSource Sound;
    [Header("VehicalsState")]
    [SerializeField] Sprite playerSprite;
    [SerializeField] Sprite mech1Sprite;

    private SphereCollider playerCollider;
    [SerializeField] MechController mech;

    void Start()
    {

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Sound.PlayOneShot(gunShot);
            Rigidbody2D bulletClone = Instantiate(bullet, gun.position, gun.rotation);
        }

            
    }
    void FixedUpdate()
    {
        Quaternion rotation = Quaternion.LookRotation(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        float speed = playerSpeed * Time.deltaTime;

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Paddle"))
        {
            ballMode.SetActive(true);
            player.SetActive(false);
            paddleMovement.enabled = true;
            playerPosition.transform.position = new Vector2(transform.position.x, transform.position.y + 6);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            transform.position = new Vector2(OCPos.transform.position.x + 2, OCPos.transform.position.y);
        }
        if (collision.CompareTag("Bullet"))
        {
            transform.position = new Vector2(OCPos.transform.position.x + 2, OCPos.transform.position.y);
        }
    }

}