using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionInstantiate : MonoBehaviour
{

    public GameObject[] GroundObstacles;
    public CarController MuscleCar;

    int random = 0;

    [SerializeField] Vector3 nextSpawnPoint;

    [SerializeField] bool tileSpawned = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Trigger"))
        {
            if (tileSpawned == false)
            {
                SpawnTile();
                tileSpawned = true;
            }
        }
    }



    private void OnTriggerExit(Collider other)
    {
        tileSpawned = false;
        
        MuscleCar.score += 20;
        Debug.Log($"+{MuscleCar.score} Distance");

        
        
    }

    void SpawnTile()
    {

        random = Random.Range(0, GroundObstacles.Length);

        GameObject tile = Instantiate(GroundObstacles[random], nextSpawnPoint, Quaternion.Euler(0, -90, 0));

        nextSpawnPoint = tile.transform.GetChild(1).transform.position;

        StartCoroutine(DestroyTile(tile));

    }


    IEnumerator DestroyTile(GameObject tile)
    {
        // Wait for the specified delay time
        yield return new WaitForSeconds(15f);

        Destroy(tile);
    }


}
