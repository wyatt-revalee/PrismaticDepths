using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public List<EnemySpawn> enemies = new List<EnemySpawn>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public GameObject[] spawnLocations;
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
        GenerateEnemies();
        GetSpawnLocations();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            //spawn an enemy
            if (enemiesToSpawn.Count > 0)
            {
                int randLocation = UnityEngine.Random.Range(0, spawnLocations.Length - 1);
                Debug.Log(spawnLocations.Length);
                Debug.Log(randLocation);

                GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], spawnLocations[randLocation].transform.position, Quaternion.identity); // spawn first enemy in our list
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

    private void GenerateEnemies()
    {
        while (currency > 0)
        {
            int randomEnemy = Random.Range(0, enemies.Count);
            if (enemies[randomEnemy].cost <= currency)
            {
                currency -= enemies[randomEnemy].cost;
                enemiesToSpawn.Add(enemies[randomEnemy].enemyPrefab);
            }
        }
    }

    private void GetSpawnLocations()
    {
        // should be split into two lists - ground and sky? Or custom type / dictionary of values for that instead?
        spawnLocations = GameObject.FindGameObjectsWithTag("EnemyGroundSpawn");
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