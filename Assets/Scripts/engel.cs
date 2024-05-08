using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovingObstacle : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 moveDirection = Vector2.right;
    private Rigidbody2D rb2;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveObstacle();
    }

    void MoveObstacle()
    {
        rb2.velocity = new Vector2(moveDirection.x * speed, rb2.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    // Engelin yönünü deðiþtirmek için bu fonksiyonu çaðýrýn
    public void ChangeDirection()
    {
        moveDirection = -moveDirection;
    }
}

