using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaddleMovement : MonoBehaviour {

    [Header("MouseMovement")]
    public bool mouse;
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float maxX_m = 15f;
    [SerializeField] float minX_m = 1f;
    [Header("KeyboardMovement")]
    public bool keyboard;
    [SerializeField] float maxX_k = 15f;
    [SerializeField] float minX_k = 1f;
    [SerializeField] float currentX = 8f;
    [SerializeField] float timeBetweenMoves = 0.3f;
    [SerializeField] float timer;
    public int KP_health = 5;
   
    void Update ()
    {
        Timer();
        if(KP_health <= 0 && keyboard == true)
        {
            GameObject gameObject = GameObject.Find("KeyboardPaddle");
            SceneManager.LoadScene("Game_Over");
        }
        if (mouse == true)
        {
            float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
            Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
            paddlePos.x = Mathf.Clamp(mousePosInUnits, minX_m, maxX_m);
            transform.position = paddlePos;
        }
        if (keyboard == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (currentX == maxX_k && timer <= 0)
                {
                    currentX = maxX_k;
                    timer += timeBetweenMoves;
                }
                else if (timer <= 0)
                {
                    currentX += 1;
                    timer += timeBetweenMoves;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if (currentX == minX_k && timer <= 0)
                {
                    currentX = minX_k;
                    timer += timeBetweenMoves;
                }
                else if (timer <= 0)
                {
                    currentX -= 1;
                    timer += timeBetweenMoves;
                }
            }
            transform.position = new Vector2(currentX, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            KP_health -= 1;
        }
    }
    void Timer()
    {
        if (timer > 0)
            timer -= Time.deltaTime;
    }
}
