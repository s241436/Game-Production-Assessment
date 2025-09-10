using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0f;


    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(-Vector3.forward * speed, ForceMode.Force);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.forward * speed, ForceMode.Force);
        }

        rb.velocity = velocity; // removes acceleration and friction
    }
}
