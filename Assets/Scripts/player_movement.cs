using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 7.0f;
    private bool isGrounded;
    private float jumpCooldown = 0.5f;
    private float lastJumpTime;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && (Time.time - lastJumpTime >= jumpCooldown))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            lastJumpTime = Time.time; // Zýplama zamanýný kaydet
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("zemin"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("zemin"))
        {
            // Zeminle temas kesildikten 0.5 saniye sonra isGrounded'ý false yap
            StartCoroutine(GroundCheckCooldown());
        }
    }

    private IEnumerator GroundCheckCooldown()
    {
        yield return new WaitForSeconds(jumpCooldown);
        isGrounded = false;
    }
}

