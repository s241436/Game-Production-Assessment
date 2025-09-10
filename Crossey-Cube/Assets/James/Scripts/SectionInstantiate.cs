using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionInstantiate : MonoBehaviour
{

    public GameObject[] GroundObstacles;
    public PlayerController PlayerController;

    int random = 0;

    Vector3 nextSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController = GetComponent<PlayerController>();

        if (other.gameObject.CompareTag("Trigger"))
        {
            SpawnTile();
            PlayerController.score += 20;
            Debug.Log($"+{PlayerController.score} Distance");
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
