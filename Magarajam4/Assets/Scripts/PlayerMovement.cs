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
    // public bool isOnGround = true;
    private BoxCollider2D boxCollider2d;

    private Rigidbody2D playerRigidbody;


    private void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        playerRigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal player movement.
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        // Player jump.
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Debug.Log("Should've worked.");
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    //private void OnCollisionEnter2D(Collision collision)
    //{

    //    Debug.Log("Collision worked without ground");
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        Debug.Log("Collision worked with ground");
    //        isOnGround = true;
    //    }
    //}

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
}
