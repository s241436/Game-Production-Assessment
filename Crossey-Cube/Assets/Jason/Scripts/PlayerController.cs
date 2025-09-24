using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0f;
    public float score = 0;
    public TextMeshProUGUI Score;

    
    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;

        rb.AddForce(Vector3.right * speed, ForceMode.Force);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(-Vector3.forward * speed, ForceMode.Force);
        }

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.forward * speed, ForceMode.Force);
        }

        rb.velocity = velocity; // removes acceleration and friction
        Score.text = score.ToString();

    }
}
