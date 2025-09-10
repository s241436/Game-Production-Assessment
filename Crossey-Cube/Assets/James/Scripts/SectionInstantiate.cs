using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionInstantiate : MonoBehaviour
{

    public GameObject[] GroundObstacles;


    int random = 0;

    Vector3 nextSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            SpawnTile();
        }
    }

    void SpawnTile()
    {
        
        random = Random.Range(0, GroundObstacles.Length);

        GameObject tile = Instantiate(GroundObstacles[random], nextSpawnPoint, Quaternion.identity);

        nextSpawnPoint = tile.transform.GetChild(1).transform.position; 
        

    }




    /*
        public float spawnDistance = 10f;s
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
