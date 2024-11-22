using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField, Min(0.0f)] private float spawnRate;

    [SerializeField] private int currentNbEnemies;
    [SerializeField] private int maxEnemy;

    private float enemySpawntTimer;
    private Pool<Enemy> enemyPool;

    [SerializeField] private Transform[] waypointList;

    private void Awake()
    {
        enemySpawntTimer = 0.0f;
        enemyPool = new Pool<Enemy>(CreateEnemy, OnGetEnemy, OnReleaseEnemy, maxEnemy);
        //_projectilePool = new Pool<Projectile>(CreateProjectile, OnGetProjectile, OnReleaseProjectile, 150, 500);


    }

    private Enemy CreateEnemy()
    {
        GameObject go = Instantiate(enemyPrefab);
        go.GetComponent<FollowWP>().SetWaypoints(waypointList);

        Enemy enemy = go.GetComponent<Enemy>();

        return enemy;
    }

    private void OnGetEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
        //enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;

    }

    private void OnReleaseEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);

    }


    private void Update()
    {

        enemySpawntTimer += Time.deltaTime;

        if (enemySpawntTimer >= spawnRate && currentNbEnemies < maxEnemy)
        {
            currentNbEnemies ++;
            enemySpawntTimer = 0.0f;

            Enemy enemy = enemyPool.Get();
            enemy.transform.position = transform.position;

        }
    }
}
