using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float moveSpeed;
    [SerializeField] private OperationCenter operationCenter;

    private Rigidbody2D rb;
    Vector2 movement;
    [Header("Interaction")]
    public bool playerDied;
    [Header("Abilitis")]
    public Transform gun;
    public Rigidbody2D bullet;
    public AudioClip gunShot;
    public AudioSource Sound;
    [SerializeField] GameObject canvas;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        operationCenter = GameObject.Find("OperationCenter").GetComponent<OperationCenter>();
    }
    private void Update()
    {
        canvas = GameObject.Find("CharacterMenu");
        if (Input.GetButtonDown("Fire1"))
        {
            Sound.PlayOneShot(gunShot);
            Rigidbody2D bulletShot = Instantiate(bullet, gun.position, gun.rotation);
        }

            
        Quaternion rotation = Quaternion.LookRotation(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward);
        transform.rotation = rotation;
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);


        movement.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        movement.y = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        rb.velocity = new Vector2(movement.x, movement.y);

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