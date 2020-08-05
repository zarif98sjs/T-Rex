using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePatterns;

    private float timeBetweenSpawn;
    public float startTimeBetweenSpawn;
    public float decreaseTime;
    public float minTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenSpawn <= 0f)
        {

            int id = Random.Range(0,obstaclePatterns.Length);

            Instantiate(obstaclePatterns[id], transform.position , Quaternion.identity);
            timeBetweenSpawn = startTimeBetweenSpawn;

            if(startTimeBetweenSpawn > minTime)
            {
                startTimeBetweenSpawn -= decreaseTime;
            }
                
        }
        else
        {
            timeBetweenSpawn -= Time.deltaTime;
        }
    }
}
