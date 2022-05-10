using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointSystem : MonoBehaviour
{
    public static PointSystem instance;
    public Text scoreText;
    public Transform player;
    int points = 0;
    // Start is called before the first frame update
    private void Awake(){
        instance=this;
    }
    void Start()
    {
        points = GameObject.Find("Player").GetComponent<PlayerDude>().points;  
        scoreText.text = "Current Score" + points.ToString();
    }
    void Update(){
        points = GameObject.Find("Player").GetComponent<PlayerDude>().points;  
        scoreText.text = "Current Score" + points.ToString();
    }

    // Update is called once per frame
    public void AddPoint(){
        points += 1;
        scoreText.text = "Current Score"+ points.ToString();
    }
}
