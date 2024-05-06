using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    public float climbSpeed = 3.0f;
    private bool isGrounded;
    private bool isClimbing;
    private Rigidbody rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = isClimbing ? Input.GetAxis("Vertical") : 0.0f;
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        if (isClimbing)
        {
            rb.velocity = new Vector3(rb.velocity.x, moveVertical * climbSpeed, rb.velocity.z);
        }
        else
        {
            rb.AddForce(movement * speed);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (transform.position.y < -5)
        {
            transform.position = startPosition;
            rb.velocity = Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("zemin"))
        {
            isGrounded = true;
            isClimbing = false;
        }
        else if (other.gameObject.CompareTag("duvar"))
        {
            isClimbing = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("zemin"))
        {
            isGrounded = false;
        }
        else if (other.gameObject.CompareTag("duvar"))
        {
            isClimbing = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            LoadNextLevel();
        }
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}

