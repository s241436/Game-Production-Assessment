using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionInstantiate : MonoBehaviour
{

    public GameObject[] GroundObstacles;

    int random = 0;

    [SerializeField] Vector3 nextSpawnPoint;
    [SerializeField] bool tileSpawned = false;

    
    void SpawnTile()
    {

        random = Random.Range(0, GroundObstacles.Length);

        GameObject tile = Instantiate(GroundObstacles[random], nextSpawnPoint, Quaternion.Euler(0, -90, 0));

        nextSpawnPoint = tile.transform.GetChild(1).transform.position;


    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Trigger"))
        {
            SpawnTile();
            // Starts a courtine on the tile that the car had triggered
            StartCoroutine(destroyTile(other.transform.parent.gameObject)); ;
        }
        

    }

    IEnumerator destroyTile(GameObject tile)
    {
        yield return new WaitForSeconds(5);
        Destroy(tile);
    }



  


}
