using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner2 : MonoBehaviour
{
    public GameObject coinSpawner;
    public bool stopSpawn = false;
    public float spawnTime;
    public float spawnCD;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnCD);
    }

    // Update is called once per frame
   public void SpawnObject()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-5,5),1,Random.Range(5,-5));
        Instantiate(coinSpawner,randomSpawnPosition, Quaternion.Euler(90,1,0));
        if(GameObject.FindGameObjectsWithTag("Coin").Length >= 5){
            stopSpawn = true;
            CancelInvoke("SpawnObject");
        }
        
    }
}
