using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Magara Jam 4

public class PlayerMovement : MonoBehaviour
{
    public float speed = 8;
    public float horizontalInput;
    public float jumpForce = 10;
    public bool isOnGround = true;

    private Rigidbody2D playerRigidbody;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal player movement.
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        // Player jump.
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision collision)
    {

        Debug.Log("Collision worked without ground");
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collision worked with ground");
            isOnGround = true;
        }
    }
}
