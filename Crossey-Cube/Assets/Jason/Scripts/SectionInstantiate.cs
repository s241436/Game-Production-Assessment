using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionInstantiate : MonoBehaviour
{
    public GameObject GroundSection;
    public GameObject SectionTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(GroundSection, new Vector3(55, 0, 0), Quaternion.identity);
        }
    }
}
