using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Magara Jam 4

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public float speed = 8;
    public float horizontalInput;
    public float jumpForce = 5;
    public BoxCollider2D boxCollider2d,Groundcheck;
    public Animator animator;
    private Rigidbody2D playerRigidbody;
    public Ýnvisibility invisibility;
    public float Health = 100;
    public GameManager manager;
    public int Cooldown = 5;
    public TextMeshProUGUI cd;
    Coroutine coroutine;


    void Start()
    {
            boxCollider2d = GetComponent<BoxCollider2D>();
            playerRigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            invisibility = GetComponent<Ýnvisibility>();
            coroutine = StartCoroutine(CooldownWait());
    }
    void Update()
    {
        
        horizontalInput = Input.GetAxis("Horizontal");
        if (Cooldown == 0)
        {
            StopCoroutine(coroutine);
        }

        if (Health <= 0)
        {
            manager.backgroundMusic.Pause();

            Destroy(gameObject);
        }

        if (horizontalInput > 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 0, transform.localRotation.z);
            animator.SetBool("ÝsRunning", true);
        }
        else if (horizontalInput < 0)
        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, 180, transform.localRotation.z);
            horizontalInput = Mathf.Abs(horizontalInput);
            animator.SetBool("ÝsRunning", true);
        }
        else
        {
            animator.SetBool("ÝsRunning",false);
        }
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);
     
        if (animator.GetBool("Jump"))
        {
            animator.SetBool("ÝsRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce * 1.6f, ForceMode2D.Impulse);
            animator.SetBool("Jump", true);
            Invoke("StopJump", 0.5f);
            Cooldown = 5;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ýnvisibility invisibilty =  gameObject.GetComponent<Ýnvisibility>();
            invisibility.invisible = true;
            Invoke("BeVisible",3);
            Cooldown = 5;
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            speed = speed * 1.7f;
            Invoke("Slow",3);
            Cooldown = 5;
        }

  

    }
    public void Slow()
    {
        speed = speed / 1.7f;
    }

    public void BeVisible()
    {
        Ýnvisibility invisibilty = gameObject.GetComponent<Ýnvisibility>();
        invisibility.invisible = false;
    }

    void StopJump()
    {
        animator.SetBool("Jump", false);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(Groundcheck.bounds.center, boxCollider2d.bounds.size + new Vector3(0,2,0), 0f, Vector2.down, .1f, platformsLayerMask);
        return raycastHit2d.collider != null;
    }

    IEnumerator CooldownWait()
    {
        yield return new WaitForSeconds(1);
        Cooldown-= 1;
        cd.text = Cooldown.ToString();
    }
    
}
