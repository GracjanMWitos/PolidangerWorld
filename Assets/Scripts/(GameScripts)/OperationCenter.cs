﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OperationCenter : MonoBehaviour
{
    [Header("Other")]
    [SerializeField] private GameObject e_button;
    [SerializeField] private GameObject disactiveCollider;
    private PlayerControler playerControler;
    [SerializeField] public bool playerIsClose;
    [Header("Interaction")]
    [SerializeField] private GameObject playerGO;
    [SerializeField] public bool O_CIsConectedToSlot;

    [Header("Mech nr.1")]
    private bool bodySelected;
    [SerializeField] Rigidbody2D body;

    [Header("Mech nr.1")]
    private bool mechNr1Selected;
    [SerializeField] Rigidbody2D mech_1;

    [Header("Mech nr.2")]
    private bool mechNr2Selected;
    [SerializeField] Rigidbody2D mech_2;

    [Header("Mech nr.3")]
    private bool mechNr3Selected;
    [SerializeField] Rigidbody2D mech_3;

    [Header("CanvasOptions")]
    [HideInInspector] public bool charactersMenuStarted;
    [SerializeField] GameObject charactersMenu;

    private void Start()
    {
        disactiveCollider.SetActive(false);
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
    }
    void Update()
    {
        ActiveCollider();
        MechSelection();

        if ((playerIsClose && Input.GetKeyDown(KeyCode.E)) || playerControler.playerisDead == true)
        {
            StartCharactersMenu();
        }

    }
    public void MechSelection()
    {
        if (bodySelected == true)
        {
            Rigidbody2D bulletShot = Instantiate(body, this.transform.position, this.transform.rotation);
            bodySelected = false;
            playerGO = GameObject.FindGameObjectWithTag("Player");
            playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        }
        if (mechNr1Selected == true)
        {
            Rigidbody2D bulletShot = Instantiate(mech_1, transform.position, transform.rotation);
            mechNr1Selected = false;
            playerGO = GameObject.FindGameObjectWithTag("Player");
            playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        }
        if (mechNr2Selected == true)
        {
            Rigidbody2D bulletShot = Instantiate(mech_2, this.transform.position, this.transform.rotation);
            mechNr2Selected = false;
            playerGO = GameObject.FindGameObjectWithTag("Player");
            playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();
        }
        if (mechNr3Selected == true)
        {
            Rigidbody2D bulletShot = Instantiate(mech_3, this.transform.position, this.transform.rotation);
            mechNr3Selected = false;
            playerGO = GameObject.FindGameObjectWithTag("Player");
            playerControler = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControler>();

        }
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
    public void Body_1Button()
    {
        bodySelected = true;
        GameReturn();
    }
    public void Mech_1Button()
    {
        mechNr1Selected = true;
        GameReturn();
    }
    public void Mech_2Button()
    {
        mechNr2Selected = true;
        GameReturn();
    }
    public void Mech_3Button()
    {
        mechNr3Selected = true;
        GameReturn();
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
        Destroy(playerGO);
        charactersMenu.SetActive(true);
        Time.timeScale = 0f;
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