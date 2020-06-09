using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] private OperationCenter operationCenter;


    Vector2 movement;
    [Header("Interaction")]
    public bool playerDied;
    [Header("Abilitis")]
    [SerializeField] public float dashingTime;
    [SerializeField] public float dashLength;
    [SerializeField] public float timeToShot;
    [Header("Components")]
    public Transform gun;
    public Rigidbody2D bullet;
    public AudioClip gunShot;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    [SerializeField] GameObject canvas;
    [SerializeField] private float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        operationCenter = GameObject.Find("OperationCenter").GetComponent<OperationCenter>();
        audioSource = GetComponent<AudioSource>();
        timer = timeToShot;
    }
    private void Update()
    {
        SlowMotion();
        Dash();
        Shooting();
        canvas = GameObject.Find("CharacterMenu");
      
        Quaternion rotation = Quaternion.LookRotation(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);


        movement.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movement.y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        rb.velocity = new Vector2(movement.x, movement.y);

    }
    void Shooting()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Mouse0) && timer <= 0)
        {
            //audioSource.PlayOneShot(gunShot);
            Rigidbody2D bulletShot = Instantiate(bullet, gun.position, gun.rotation);
            timer = timeToShot;     
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && timer <= 0)
            timer = timeToShot;
    }
    void SlowMotion()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Time.timeScale = 0.20f;
            moveSpeed *= 4;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Time.timeScale = 1f;
            moveSpeed /= 4;
        }
        
    }
    void Dash()
    {
        Vector2 dashMove = new Vector2(transform.position.x, transform.position.y + dashLength);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = Vector2.Lerp(transform.position, dashMove, dashingTime / Time.deltaTime);
            Time.timeScale = 0.7f;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            transform.position = new Vector2(operationCenter.transform.position.x, operationCenter.transform.position.y);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            
            transform.position = new Vector2(operationCenter.transform.position.x, operationCenter.transform.position.y);
            Destroy(gameObject);
            playerDied = true;
            operationCenter.CharactersMenu();
        }
    }

}