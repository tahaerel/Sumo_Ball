using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject strongEnemy;
    public GameObject powerUpPrefab;
    public GameObject gunPowerUp;
    public GameObject smashPowerUp;
    public GameObject boss;
    private float spawnRange = 9.0f;
    public int enemyCount;
    public int waveNumber = 1;
    public int powerUpNumber = 1;

    private void Start()
    {
        SpawnInitialWave();
        SpawnPowerUps();
        InvokeRepeating("SpawnStrongEnemy", 5f, 15f);
        InvokeRepeating("SpawnRandomPowerUp", 5f, Random.Range(5f, 10f));
        Invoke("SpawnBoss", 25f);
    }

    private void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerUps();
            SpawnRandomPowerUp();
            SpawnRandomPowerUp();
        }
    }

    private void SpawnInitialWave()
    {
        SpawnEnemyWave(waveNumber);
    }

    private void SpawnEnemyWave(int enemyToSpawn)
    {
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    private void SpawnStrongEnemy()
    {
        Instantiate(strongEnemy, GenerateSpawnPosition(), Quaternion.identity);
    }

    private void SpawnRandomPowerUp()
    {
        int randomPowerUpIndex = Random.Range(0, 2);
        GameObject powerUp = randomPowerUpIndex == 0 ? gunPowerUp : smashPowerUp;
        Instantiate(powerUp, GenerateSpawnPosition(), Quaternion.identity);
    }

    private void SpawnPowerUps()
    {
        for (int i = 0; i < powerUpNumber; i++)
        {
            Instantiate(powerUpPrefab, GenerateSpawnPosition(), Quaternion.identity);
        }
    }

    private void SpawnBoss()
    {
        Instantiate(boss, GenerateSpawnPosition(), Quaternion.identity);
    }

    private Vector3 GenerateSpawnPosition()
    {
        Vector3 randomPos = Random.insideUnitSphere * spawnRange;
        randomPos.y = 0;
        return randomPos;
    }
}
