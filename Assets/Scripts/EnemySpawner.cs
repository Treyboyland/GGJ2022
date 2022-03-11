using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Vector4 spawnRect;

    [SerializeField]
    Vector2 secondsBetweenSpawns;

    [SerializeField]
    Vector2Int numToSpawn;

    [SerializeField]
    Vector2Int numToSpawnInitial;

    [SerializeField]
    MonoPool<Enemy> pool;
    float secondsBeforeSpawn;

    float elapsed = 0;


    // Start is called before the first frame update
    void Start()
    {
        secondsBeforeSpawn = Random.Range(secondsBetweenSpawns.x, secondsBetweenSpawns.y);
        InitializeScreen();
    }

    void InitializeScreen()
    {
        int numToSpawn = Random.Range(numToSpawnInitial.x, numToSpawnInitial.y);
        for (int i = 0; i < numToSpawn; i++)
        {
            SpawnEnemy();
        }
    }

    void SpawnMore()
    {
        elapsed = 0;
        secondsBeforeSpawn = Random.Range(secondsBetweenSpawns.x, secondsBetweenSpawns.y);
        int numToSpawn = Random.Range(this.numToSpawn.x, this.numToSpawn.y);
        for (int i = 0; i < numToSpawn; i++)
        {
            SpawnEnemy();
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= secondsBeforeSpawn)
        {
            SpawnMore();
        }
        if (!pool.AnyActive())
        {
            InitializeScreen();
        }
    }

    Vector3 GetRandomSpawnOffset()
    {
        float x, y, z;
        x = Random.Range(spawnRect.x, spawnRect.y);
        y = Random.Range(spawnRect.z, spawnRect.w);
        z = 0;

        return new Vector3(x, y, z);
    }

    void SpawnEnemy()
    {
        var enemy = pool.GetObject();
        enemy.transform.position = transform.position + GetRandomSpawnOffset();
        enemy.gameObject.SetActive(true);
    }
}
