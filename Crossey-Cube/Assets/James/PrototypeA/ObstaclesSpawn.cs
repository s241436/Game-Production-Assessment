using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawn : MonoBehaviour
{

    public GameObject[] GroundObstacles;
    public GameObject[] FlyObstacles;

    [SerializeField] GameObject flyPortal;
    [SerializeField] GameObject groundPortal;

    int random = 0;


}
