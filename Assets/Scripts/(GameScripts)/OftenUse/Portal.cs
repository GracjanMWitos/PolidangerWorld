using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private bool thisPortalChangeLevel;
    [SerializeField] private string sceneName;
    [SerializeField] private Transform secondPortal;
    [SerializeField] private GameObject player;
    [SerializeField] private PauseScript pause;
    [SerializeField] private int distanceToPortal;
    LevelManager levelManager;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        pause = GameObject.Find("Managers").GetComponent<PauseScript>();
        levelManager = GameObject.Find("Managers").GetComponent<LevelManager>();
    }
    void FixedUpdate()
    {
        if (pause.characterMenuOn == false){ player = GameObject.FindGameObjectWithTag("Player");}
        if (pause.characterMenuOn){ player = null; }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (thisPortalChangeLevel)
                levelManager.SelectLevel(sceneName);
                
            if (!thisPortalChangeLevel)
            {
                Vector2 pos = new Vector2(secondPortal.position.x, secondPortal.position.y);
                player.transform.position = pos ;
            }


        }
    }
}
