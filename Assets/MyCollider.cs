using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter(Collider other){
        if(other.name=="Player"){
            
            Destroy(gameObject);
            other.GetComponent<PlayerDude>().points++;
        }
    }
}
