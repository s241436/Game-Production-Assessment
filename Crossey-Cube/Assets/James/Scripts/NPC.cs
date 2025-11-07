using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator animator;

    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void TurnOnRagdoll()
    {
        animator.enabled = false;
    }

    [SerializeField] float explosionforce = 15f;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.AddExplosionForce(explosionforce, collision.contacts[0].point, 5f, 1f, ForceMode.Impulse);
                
            TurnOnRagdoll();
        }
    }
   
}
