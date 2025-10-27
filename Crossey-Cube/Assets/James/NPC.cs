using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Animator animator;

    void TurnOnRagdoll()
    {
        animator.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TurnOnRagdoll();
        }
    }
   
}
