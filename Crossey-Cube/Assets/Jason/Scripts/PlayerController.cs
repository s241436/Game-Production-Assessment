using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 0f;
    public float steerspeed = 0f;
    public float score = 0;
    public TextMeshProUGUI ScoreHint;
    public float SavedScore = 0;

    void Awake()
    {
        score = score - 20;
    }
    
    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;

        rb.AddForce(Vector3.forward * speed, ForceMode.Force);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * steerspeed, ForceMode.Force);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * steerspeed, ForceMode.Force);
        }

        rb.velocity = velocity; // removes acceleration and friction
        ScoreHint.text = score.ToString();
        PlayerPrefs.SetFloat("PlayerScoreKey", score);
        PlayerPrefs.Save();

    }
}
