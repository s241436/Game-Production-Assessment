using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition3D : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 mousePosition3D = hit.point;
            Debug.Log("Mouse Position in 3D: " + mousePosition3D);
            // You can use mousePosition3D for further processing
        }
        else
        {
            Debug.Log("Mouse is not over a collider.");
        }
    }
}
