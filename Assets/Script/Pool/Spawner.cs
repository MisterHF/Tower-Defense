using UnityEngine;



public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField, Min(0.0f)] private float spawnRate;

    [SerializeField] private int currentNbEnemies;
    [SerializeField] private int maxEnemy;

    private float enemySpawntTimer;


    [SerializeField] private Transform[] waypointList;

    private void Awake()
    {
        enemySpawntTimer = 0.0f;
    }

    private Enemy CreateEnemy()
    {
        GameObject go = Instantiate(enemyPrefab);
        go.GetComponent<FollowWP>().SetWaypoints(waypointList);

        Enemy enemy = go.GetComponent<Enemy>();
        enemy.transform.position = transform.position;
        go.GetComponent<FollowWP>().spawner = this;
        return enemy;
    }

    public void OnGetEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);

    }

    public void OnReleaseEnemy(Enemy enemy)
    {
        //enemy.gameObject.SetActive(false);
        Destroy(enemy.gameObject);
    }


    private void Update()
    {

        enemySpawntTimer += Time.deltaTime;

        if (enemySpawntTimer >= spawnRate && currentNbEnemies < maxEnemy)
        {
            currentNbEnemies++;
            enemySpawntTimer = 0.0f;

            CreateEnemy();


        }
    }
}
