using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OperationCenter : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private GameObject e_button;
    [SerializeField] private GameObject disactiveCollider;
    private PlayerController playerController;
    [SerializeField] public bool playerIsClose;
    [Header("Interaction")]
    [SerializeField] public bool _OCIsConectedToSlot;

    [Header("CanvasOptions")]
    [HideInInspector] public bool charactersMenuStarted;
    [SerializeField] GameObject charactersMenu;

    private void Start()
    {
        disactiveCollider.SetActive(false);
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Update()
    {
        ActiveCollider();
        MechSelection();

        if ((playerIsClose && Input.GetKeyDown(KeyCode.E)))
        {
            StartCharactersMenu();
        }

    }
    public void MechSelection()
    {

    }
    public void ActiveCollider()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            disactiveCollider.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            disactiveCollider.SetActive(false);
        }
    }
    public void GameReturn()
    {
        charactersMenu.SetActive(false);
        charactersMenuStarted = false;
        Time.timeScale = 1;
    }
    public void StartCharactersMenu()
    {
        charactersMenuStarted = true;
        charactersMenu.SetActive(true);
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
;           e_button.SetActive(true);
        }
        if(collision.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            e_button.SetActive(false);
        }
    }
}
