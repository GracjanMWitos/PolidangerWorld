using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private OperationCenter operationCenter;
    Vector2 movement;
    [Header("Interaction")]
    [SerializeField] private float timeToDieOnRedBlock;
    [SerializeField] private float timeSpendedOnRedBlock;
    [SerializeField] private bool noRespawnPleace;
    [SerializeField] public bool playerisDead;
    [SerializeField] private bool playerisOnRedBlock;
    [Header("    Teleportation")][Header("Abilitis")]
    public float cursorToPlayer;
    [Header("    Shooting")]
    [SerializeField] public float timeToShot;
    public Transform gun;
    public Rigidbody2D bullet;
    public AudioClip gunShot;
    [Header("Others")]
    private AudioSource audioSource;
    private Rigidbody2D rb;
    [SerializeField] GameObject canvas;
    [SerializeField] private float timer;
    public Vector2 mousePosition;



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
        Teleportation();
        Shooting();
        canvas = GameObject.Find("CharacterMenu");
      
        Quaternion rotation = Quaternion.LookRotation(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);

        movement.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movement.y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        rb.velocity = new Vector2(movement.x, movement.y);

        if (playerisOnRedBlock)
            timeSpendedOnRedBlock += Time.deltaTime;
        if (timeSpendedOnRedBlock >= timeToDieOnRedBlock)
        {
            Destroy(gameObject);
            playerisDead = true;
            operationCenter.StartCharactersMenu();
        }
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
    void Teleportation()
    {
        Vector3 teleportationPointPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z + 10));
        if (Input.GetKeyUp(KeyCode.Space) && timer <= 0)
        {
            transform.position = teleportationPointPosition;
            timer = timeToShot;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
    }
    void InteractionWithPortals()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            transform.position = new Vector2(operationCenter.transform.position.x,+
                operationCenter.transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {        
            Destroy(gameObject);
            playerisDead = true;
            operationCenter.StartCharactersMenu();
        }
        if (collision.CompareTag("RedBlocks"))
        {
            playerisOnRedBlock = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("RedBlocks"))
        {
            playerisOnRedBlock = false;
            timeSpendedOnRedBlock = 0;
        }
    }
}