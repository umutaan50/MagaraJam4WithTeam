using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Magara Jam 4

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public float speed = 8;
    public float horizontalInput;
    public float jumpForce = 10;
    private BoxCollider2D boxCollider2d;

    private Rigidbody2D playerRigidbody;


    private void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        playerRigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
        Debug.Log(IsGrounded());
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }



    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
}
