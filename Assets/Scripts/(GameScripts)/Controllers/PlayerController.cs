using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Transform gameobjectTransform;
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private OperationCenter operationCenter;
    Vector2 movement;
    [Header("Statistics")]
    GameManager gameManager;
    
    public Slider healthSlider;
    [SerializeField] public int currentHealthPoints;
    [SerializeField] public int maxHealthPointsCapacity;

    [HideInInspector] public int currenrPowerPoints;
    [SerializeField] public int maxPowerPointsCapacity;
    
    [HideInInspector] public int currentEnginaryPoints;
    [SerializeField] public int maxEnginaryPointsCapacity;
    
    [SerializeField] SpriteRenderer highlightObject;
    [SerializeField] private float timeToDieOnRedBlock;
    [SerializeField] private float timeSpendedOnRedBlock;
    [HideInInspector] public bool playerisDead;
    [SerializeField] private bool playerisOnRedBlock;
    [Header("Abilitis")]
    [Header("Others")]
    private AudioSource audioSource;
    private Rigidbody2D rb;
    [SerializeField] GameObject canvas;
    [SerializeField] private float timer;
    public Vector2 mousePosition;



    void Start()
    {
        gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        operationCenter = GameObject.Find("OperationCenter").GetComponent<OperationCenter>();
        audioSource = GetComponent<AudioSource>();
        highlightObject = GameObject.Find("HighLight").GetComponent<SpriteRenderer>();
        maxHealthPointsCapacity = gameManager.maxHealthPointsCapacity;
        maxPowerPointsCapacity = gameManager.maxPowerPointsCapacity;
        maxEnginaryPointsCapacity = gameManager.maxEnginaryPointsCapacity;
        currentHealthPoints = maxHealthPointsCapacity;
        currenrPowerPoints = maxPowerPointsCapacity;
        currentEnginaryPoints = maxEnginaryPointsCapacity;

    }
    private void Update()
    {
        healthSlider.value = currentHealthPoints;
        healthSlider.maxValue = maxHealthPointsCapacity;
        SlowMotion();
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
            currentHealthPoints -= 4;
            timeSpendedOnRedBlock = 0;
        }
        if(currentHealthPoints <= 0)
        {
            Debug.Log("martwy");
            Destroy(gameObject);
            playerisDead = true;
        }
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



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            transform.position = new Vector2(operationCenter.transform.position.x, +
                operationCenter.transform.position.y);
        }
        if (collision.collider.CompareTag("Interactivable"))
            highlightObject.enabled = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Interactivable"))
            highlightObject.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            currentHealthPoints -= 10;
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
