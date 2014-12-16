using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour
{

    public GameObject[] obstacles;
    public GameObject[] enemies;
    public GameObject[] bonuses;

    public int minEnemySpawnCoolDown;
    public int maxEnemySpawnCoolDown;

    public int minObstacleSpawnCoolDown;
    public int maxObstacleSpawnCoolDown;

    public int minBonusSpawnCoolDown;
    public int maxBonusSpawnCoolDown;

    private float obstacleSpawnCoolDown;
    private float enemySpawnCoolDown;
    private float bonusSpawnCoolDown;

    void Start()
    {
        UpdateSpawnCoolDowns();
    }


    private void UpdateEnemySpawnCoolDown()
    {
        UpdateCoolDown(ref this.enemySpawnCoolDown);

        if (this.enemySpawnCoolDown <= 0)
        {
            this.enemySpawnCoolDown = Random.Range(minEnemySpawnCoolDown, maxEnemySpawnCoolDown);
            SpawnEnemy();
        }
    }

    private void UpdateObstacleSpawnCoolDown()
    {
        UpdateCoolDown(ref this.obstacleSpawnCoolDown);
        if (this.obstacleSpawnCoolDown <= 0)
        {
            this.obstacleSpawnCoolDown = Random.Range(minObstacleSpawnCoolDown, maxObstacleSpawnCoolDown);
            SpawnObstacle();
        }
    }

    private void UpdateBonusSpawnCoolDown()
    {
        UpdateCoolDown(ref this.bonusSpawnCoolDown);
        if (this.bonusSpawnCoolDown <= 0)
        {
            this.bonusSpawnCoolDown = Random.Range(minBonusSpawnCoolDown, maxBonusSpawnCoolDown);
            SpawnBonus();
        }
    }

    void Update()
    {
        UpdateSpawnCoolDowns();
    }

    private void UpdateSpawnCoolDowns()
    {
        UpdateBonusSpawnCoolDown();
        UpdateObstacleSpawnCoolDown();
        UpdateEnemySpawnCoolDown();
    }

    private void UpdateCoolDown(ref float coolDown)
    {
        coolDown -= Time.deltaTime;
    }

    private void SpawnEnemy()
    {
        // Todo elaborate
        SpawnObject(this.enemies[Random.Range(0, this.enemies.Length)], this.transform.position);
    }

    private void SpawnObstacle()
    {
        GameObject spawnObject;
        while (true)
        {
            spawnObject = this.obstacles[Random.Range(0, this.obstacles.Length)];
            if (spawnObject.name == "Tunnel")
            {
                if (GameObject.FindGameObjectWithTag("Tunnel") != null)
                {
                    continue;
                }
            }

            break;
        }

        SpawnObject(spawnObject, new Vector3(0, 0, this.transform.position.z));
    }

    private void SpawnBonus()
    {
        SpawnObject(this.bonuses[Random.Range(0, this.bonuses.Length)], this.transform.position);
    }

    private void SpawnObject(GameObject obj, Vector3 position)
    {
        Instantiate(obj, position, obj.transform.rotation);
    }

}