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
/*
    public float spawnDistance = 10f;
    private float lastSpawnX;

    void GroundSpawnObstacles(Collider other)
    {
        random = Random.Range(0, GroundObstacles.Length);
        lastSpawnX += spawnDistance;
        Vector3 spawnPos = new Vector3(lastSpawnX, 0, 0);


        if (portalSpawned == false)
        {
            Instantiate(groundPortal, spawnPos, Quaternion.identity);
            portalSpawned = true;
        }
        else
        {

            Instantiate(GroundObstacles[random], spawnPos, Quaternion.identity);
        }


    }*/

}
