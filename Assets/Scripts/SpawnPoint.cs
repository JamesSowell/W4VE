using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float minTime;
    public float decreaseTime;


    public float alternativeTime;
    public float alternativeTime2;

    public GameObject enemy;

    void Start()
    {
       
    }

    void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);

            if (Spawner.waveTwo)
            {
                startTimeBtwSpawns = alternativeTime2;
            }
            if (Spawner.waveThree)
            {
                startTimeBtwSpawns = alternativeTime;
            }
            if (Spawner.waveFour)
            {
                Debug.Log("THis shoudl work now");
                if(startTimeBtwSpawns > minTime)
                {
                    startTimeBtwSpawns -= decreaseTime;
                }
            }
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
