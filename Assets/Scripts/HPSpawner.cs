using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSpawner : MonoBehaviour
{
    public float startTimeBtwSpawns;
    private float timeBtwSpawns;

    public Transform[] spawnPoints;

    public GameObject HP;

    private void Update()
    {
        if(Spawner.killCount >= 20)
        {
            int rand = Random.Range(0, 4);
            if(timeBtwSpawns <= 0)
            {
                Instantiate(HP, spawnPoints[rand].position, Quaternion.identity);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
