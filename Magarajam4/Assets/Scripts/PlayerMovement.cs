using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Magara Jam 4

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public float speed = 8;
    public float horizontalInput;
    public float jumpForce = 5;
    public bool ÝsGrounded;
    private BoxCollider2D boxCollider2d;
    private float SuperJumpCooldown = 5;
    Coroutine SuperJumpCooldownwaitcr;
    private Rigidbody2D playerRigidbody;
    public enum item { SuperJump,Ýnvisibility,Hyperspeed };
    public List<item> hasitem;

    IEnumerator SuperJumpCooldownwait()
    {
        yield return new WaitForSeconds(1);
        SuperJumpCooldown -= 1;
    }
    private void Awake()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        playerRigidbody = transform.GetComponent<Rigidbody2D>();
        SuperJumpCooldownwaitcr = StartCoroutine(SuperJumpCooldownwait());
        
    }

    void Update()
    {
        if (SuperJumpCooldown == 0)
        {
            StopCoroutine(SuperJumpCooldownwaitcr);
        }
        else
        {
            SuperJumpCooldownwaitcr = StartCoroutine(SuperJumpCooldownwait());

        }
        ÝsGrounded = IsGrounded();
        horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput == 0)
        {
            gameObject.GetComponent<Animator>().SetBool("ÝsRunning",false);
        }
        else
        {

            gameObject.GetComponent<Animator>().SetBool("ÝsRunning", true);
        }
        if (horizontalInput < 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, 180, transform.localRotation.z));
            horizontalInput = Mathf.Abs(horizontalInput);
        }
        else if(horizontalInput > 0)
        {
            transform.localRotation = Quaternion.Euler(new Vector3(transform.localRotation.x, 0, transform.localRotation.z));

        }
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
        Debug.Log(IsGrounded());
        if (Input.GetKeyDown(KeyCode.Space) && ÝsGrounded)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            ÝsGrounded = false;
        }
    }



    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
    public void SuperJump()
    {
        if (SuperJumpCooldown != 0) return;
        SuperJumpCooldown = 5;
        playerRigidbody.AddForce(Vector3.up * jumpForce * 2, ForceMode2D.Impulse);
        ÝsGrounded = false;
        

    }
}
