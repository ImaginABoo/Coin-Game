using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;

    public float timer = 20;
    public int counter = 0;
    //public float timeInSecond = Mathf.FlootToInt(timer % 60);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0){
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-5,5),1,Random.Range(-5,5));
            Instantiate(coinPrefab,randomSpawnPosition,Quaternion.identity);
            timer -= Time.time;
            counter += 1;
        }
        else if (timer ==0 && counter < 5){
            timer = 20;
        }
        else if(timer ==0 && counter == 5){
            timer =0;
        }
        
    }
}
