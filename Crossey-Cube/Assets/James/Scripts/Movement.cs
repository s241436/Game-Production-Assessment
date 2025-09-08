using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] Rigidbody rb;
    [SerializeField] float jumpForce;
    [SerializeField] float force;
    [SerializeField] Vector3 boxSize;
    [SerializeField] LayerMask GroundMask;

    bool jumpRight;
    bool jumpLeft;
    bool jumpForward;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpForward = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

            jumpRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {

            jumpLeft = true;
        }
        
        
    }

    private void FixedUpdate()
    {
        float currentHorizontalInput = Input.GetAxisRaw("Horizontal");

        if (CheckIfGrounded())
        {
            if (jumpForward)
            {
                rb.AddForce(Vector3.forward * force, ForceMode.Impulse);

                rb.velocity = Vector3.up * jumpForce;
                jumpForward = false;
            }
            else if (jumpRight)
            {
                rb.AddForce(Vector3.right * force, ForceMode.Impulse);

                rb.velocity = Vector3.up * jumpForce;
                jumpRight = false;
            }
            else if (jumpLeft)
            {
                rb.AddForce(Vector3.left * force, ForceMode.Impulse);

                rb.velocity = Vector3.up * jumpForce;
                jumpLeft = false;
            }
        }
        

       
    }

    bool CheckIfGrounded()
    {
        // Checks collision by creating a box slightly bigger than the cube size and detects collision with only Groundmask objects
        bool BoxCollision = Physics.CheckBox(transform.position, boxSize * 0.5f, transform.rotation, GroundMask);


        return BoxCollision;


    }





}
