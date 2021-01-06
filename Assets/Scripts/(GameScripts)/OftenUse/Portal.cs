using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Portal : MonoBehaviour
{
    [SerializeField]private GameObject canvas;
    [SerializeField] private bool thisPortalIsChangingLevel;
    [SerializeField] private bool thisPortalIsStartingLevel;
    [SerializeField] private string nextSceneName;
    [SerializeField] private GameObject secondPortal;
    [SerializeField] private GameObject player;
    private LevelManager levelManager;
    [SerializeField] private Animator anim;
    public float timer;

    void Awake()
    {
        GameManager gameManager = GameObject.Find("Managers").GetComponent<GameManager>();
        foreach (GameObject gameObject in gameManager.objectsThatPausingGame)
            if (gameObject.name == ("LeaveLevel"))
                canvas = gameObject;
        levelManager = GameObject.Find("Managers").GetComponent<LevelManager>();
        if (thisPortalIsChangingLevel)
        {
            anim.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if (timer > 0) timer -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (thisPortalIsChangingLevel)
                canvas.SetActive(true);

            if (!thisPortalIsChangingLevel && !thisPortalIsStartingLevel && timer <= 0) 
            {
                Vector2 pos = new Vector2(secondPortal.transform.position.x, secondPortal.transform.position.y);
                player.transform.position = pos ;
                secondPortal.GetComponent<Portal>().timer = 0.3f;
            }
        }
    }
}
