using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterMovementScript : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float MoveSpeed = 10;
    [SerializeField] float Jump = 100;

    [SerializeField] Transform cam;

    bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horInput = Input.GetAxisRaw("Horizontal") * MoveSpeed;
        float verInput = Input.GetAxisRaw("Vertical") * MoveSpeed;

        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        Vector3 forwardRelative = verInput * camForward;
        Vector3 rightRelative = horInput * camRight;

        Vector3 moveDir = forwardRelative + rightRelative;

        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = new Vector3(rb.velocity.x, Jump, rb.velocity.z);
                isGrounded = false;
            }
       
        }
       

        transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
