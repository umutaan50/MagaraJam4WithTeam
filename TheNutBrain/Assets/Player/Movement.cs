using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float Speed = 5f;
    [SerializeField]
    Animator animations;
    bool ÝsGrounded;
    bool CanJump = true;

    

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1 * Speed * Time.deltaTime ,0,0);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 180, transform.rotation.x));
            animations.SetBool("ÝsWalking", true);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, 0 , transform.rotation.x));
            animations.SetBool("ÝsWalking", true);


        }
        else
        {
            animations.SetBool("ÝsWalking", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && ÝsGrounded)
        {
            if (CanJump)
            {
                ÝsGrounded = false;
                animations.SetBool("jump", true);
                Invoke("Jump", 0.2f);
                CanJump = false;
            }

        }
        else
        {
            animations.SetBool("jump", false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        ÝsGrounded = true;
    }
    void Jump()
    {
        transform.position += new Vector3(0, Speed / 3, 0);
        CanJump = true;
    }
}
