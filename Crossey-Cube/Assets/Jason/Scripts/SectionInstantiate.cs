using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class SectionInstantiate : MonoBehaviour
{
    public GameObject GroundSection;
    public GameObject SectionTrigger;
    public PlayerController PlayerController;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController = GetComponent<PlayerController>();

        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(GroundSection, new Vector3(55, 0, 0), Quaternion.identity);
            PlayerController.score += 20;
            Debug.Log($"+{PlayerController.score} Distance");
        }
    }
}
