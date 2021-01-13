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
    private GameManager playerStatistics;
    public short xp_Multiplier;
    public short playerLevel;
    public Slider health_Slider;
    [SerializeField] public int currentHealthPoints;
    [SerializeField] public int maxHealthPointsCapacity;
    public Slider Power_Slider;
    [HideInInspector] public int currenrPowerPoints;
    [SerializeField] public int maxPowerPointsCapacity;
    public Slider EnginaryPoints_Slider;
    [HideInInspector] public int currentEP;
    [SerializeField] public int maxEPCapacity;
    [SerializeField] public int xp;
    [Header("PlayerState")]
    [SerializeField] private float timeToDieOnRedBlock;
    [SerializeField] private float timeSpendedOnRedBlock;
    [SerializeField] private bool playerisOnRedBlock;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    short deathNumber = 0;
    short priceForDeath = 5; // how many hp will be reduced from max mana points for next death
    void Start()
    {
        health_Slider = GameObject.Find("PlayerHealthSlider").GetComponent<Slider>();
        playerStatistics = GameObject.Find("Managers").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        operationCenter = GameObject.Find("OperationCenter").GetComponent<OperationCenter>();
        audioSource = GetComponent<AudioSource>();
        maxHealthPointsCapacity = playerStatistics.maxHealthPointsCapacity;
        maxPowerPointsCapacity = playerStatistics.maxPowerPointsCapacity;
        maxEPCapacity = playerStatistics.maxEnginaryPointsCapacity;
        PlayerStatisticsReturn();
        
    }
    private void Update()
    {

        health_Slider.value = currentHealthPoints;
        health_Slider.maxValue = maxHealthPointsCapacity;
        SlowMotion();
        Quaternion rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward),10*Time.deltaTime);
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
            transform.position = operationCenter.transform.position;
            PlayerStatisticsReturn(); 
            deathNumber += 1;
            currenrPowerPoints -= deathNumber * priceForDeath;
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
    public void Respawn(Rigidbody2D playerRB)
    {
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Instantiate(playerRB, GameObject.Find("OperationCenter").transform.position, Quaternion.identity);
        Time.timeScale = 1f;
    }
    void PlayerStatisticsReturn()
    {
        currentHealthPoints = maxHealthPointsCapacity;
        currenrPowerPoints = maxPowerPointsCapacity;
        currentEP = maxEPCapacity;
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
