using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour {

    [SerializeField] PaddleMovement paddle1;
    Vector2 paddleToBallVector;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject StartUpText;
    [SerializeField] GameObject buttonToNextLvl;
    [SerializeField] GameObject loseColDisactive;
    [SerializeField] float speed;
    private bool isShooted;
    public int score;
    private int scorePart;
    public int goal;
    public float angle;
    void Start()
    {
        score = 0;
        speed *= 100;
        paddleToBallVector = transform.position - paddle1.transform.position;
        isShooted = false;
    }
    void Update ()
    {
        if(goal <= score)
        {
            loseColDisactive.SetActive(false);
            buttonToNextLvl.SetActive(true);
        }
        if (Input.GetKey(KeyCode.Mouse0) && isShooted == false)
        {
            isShooted = true;
            Vector2 dir = new Vector2(angle, 1);
            rb.velocity = dir * speed * Time.deltaTime;
            Destroy(StartUpText);
        }
        if(isShooted == false)
        {
            Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
            transform.position = paddlePos + paddleToBallVector;
            angle = Random.Range(-0.9f, 0.9f);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("BrokenBlock"))
        {
            scorePart += 1;
            if(scorePart == 3)
            {
                scorePart -= 3;
                score += 1;
            }
        }
        if (collision.collider.CompareTag("Weapon"))
        {
            score += 1;
        }
    }
}
