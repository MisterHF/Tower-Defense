using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] waypointList;

    [SerializeField, Min(0.0f)] private float spawnRate = 1.0f;
    [SerializeField, Min(0.0f)] private float timeBetweenWaves = 5.0f;
    [SerializeField] private int enemiesPerWave = 5;
    [SerializeField] private int waveIncrement = 2;
    [SerializeField] private int maxWave = 10;

    private int ennemiesDeath;
    private int currentWave = 1;
    private int enemiesSpawnedInWave = 0;
    private float enemySpawnTimer = 0.0f;
    private float waveCooldownTimer = 0.0f;

    private bool isWaveActive = true;

    private void Awake()
    {
        enemySpawnTimer = 0.0f;
        waveCooldownTimer = 0.0f;
    }

    private void Update()
    {
        if (isWaveActive)
        {
            SpawnEnemies();
        }
        else
        {
            HandleWaveCooldown();
        }
    }

    private void SpawnEnemies()
    {
        enemySpawnTimer += Time.deltaTime;

        if (enemySpawnTimer >= spawnRate && enemiesSpawnedInWave < enemiesPerWave)
        {
            enemySpawnTimer = 0.0f;

            CreateEnemy();
        }
        if (enemiesSpawnedInWave >= enemiesPerWave && enemiesSpawnedInWave >= 0)
        {
            isWaveActive = false;
            waveCooldownTimer = 0.0f;
        }
    }

    private void HandleWaveCooldown()
    {
        waveCooldownTimer += Time.deltaTime;

        if (waveCooldownTimer >= timeBetweenWaves)
        {
            StartNewWave();
        }
    }

    private void StartNewWave()
    {
        if (currentWave < maxWave)
        {
            currentWave++;
            enemiesPerWave += waveIncrement;
            ennemiesDeath = 0;
            enemiesSpawnedInWave = 0;   
            isWaveActive = true;
        }
        else
        {
            this.enabled = false;
        }
    }

    private void CreateEnemy()
    {
        GameObject go = Instantiate(enemyPrefab);
        go.GetComponent<FollowWP>().SetWaypoints(waypointList);
        go.transform.position = transform.position;
        go.GetComponent<FollowWP>().spawner = this;

        Enemy enemy = go.GetComponent<Enemy>();
        enemy.spawner = this;

        enemiesSpawnedInWave++;
    }

    public void OnReleaseEnemy(Enemy enemy)
    {
        if(ennemiesDeath >= enemiesPerWave)
        {
            StartNewWave();
        }
        Destroy(enemy.gameObject);
        ennemiesDeath++;
    }
}

