using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public List<EnemySpawn> enemies = new List<EnemySpawn>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public List<Transform> spawnLocations = new List<Transform>();
    public int currency;
    public int world;
    public int level;

    //Intervals and timers
    public int waveDuration;
    public float waveTimer;
    private float spawnInterval;
    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            //spawn an enemy
            if (enemiesToSpawn.Count > 0)
            {
                int randLocation = UnityEngine.Random.Range(0, spawnLocations.Count - 1);
                // Debug.Log("spawnLocations.Count: " +  spawnLocations.Count.ToString());
                // Debug.Log("spawnLocations.Count", spawnLocations.Count);

                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocations[randLocation].position, Quaternion.identity); // spawn first enemy in our list
                enemiesToSpawn.RemoveAt(0); // and remove it
                spawnTimer = spawnInterval;
            }
            else
            {
                waveTimer = 0; // if no enemies remain, end wave
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }
}

[System.Serializable]
public class EnemySpawn
{
    public GameObject enemyPrefab;
    public int cost;
}

[System.Serializable]
public class Boss
{
    public GameObject bossPrefab;
}