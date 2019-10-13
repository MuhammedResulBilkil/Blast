using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemySpawnController : MonoBehaviour
{
    public Transform[] enemySpawnPoints;
    public GameObject[] enemyObjects;

    public float enemySpawnTime = 0.5f;

    private int count = 0;
    private int enemyCount = 0;
    private float time = 0;
    //[SerializeField] [Header("Test Enemy Spawn Point")]
    //private Vector3 tempSpawnPoint = new Vector3(50f, 50f, 0f);

    private Queue<GameObject> totalEnemies = new Queue<GameObject>();

#pragma warning disable 0649
    [SerializeField]
    private Transform enemySpawnParentObject;
#pragma warning restore 0649

    public static EnemySpawnController Instance { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        for (int i = 0; i < 100; i++)
        {
            GameObject enemyGo = Instantiate(enemyObjects[UnityEngine.Random.Range(0, enemyObjects.Length)], enemySpawnParentObject);
            enemyGo.SetActive(false);
            totalEnemies.Enqueue(enemyGo);
        }

        Debug.Log("Total Enemies On The Queue = " + totalEnemies.Count);

        InvokeRepeating("ShowEnemyCount", 0f, 5f);

        //StartCoroutine(SpawningEnemies());
    }

    public IEnumerator ReturnToPool(GameObject enemy, float deathAnimLength)
    {
        yield return new WaitForSeconds(deathAnimLength);

        enemy.SetActive(false);
        enemy.transform.position = enemySpawnParentObject.position;
        totalEnemies.Enqueue(enemy);
        enemyCount--;

        yield return null;
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time >= enemySpawnTime)
        {
            if (enemyCount < 100 && totalEnemies.Count <= 100)
            {
                count = UnityEngine.Random.Range(0, 4);

                GameObject spawnedEnemy = totalEnemies.Dequeue();
                spawnedEnemy.transform.position = enemySpawnPoints[count].position;
                spawnedEnemy.transform.rotation = Quaternion.identity;

                spawnedEnemy.SetActive(true);
                enemyCount++;
            }
            time = 0f;
        }
        
        
    }

    private void ShowEnemyCount()
    {
        Debug.Log("Enemies On The Scene = " + enemyCount);
    }

    public void ResetPositions()
    {
        foreach (GameObject enemy in totalEnemies)
        {
            enemy.SetActive(false);
            enemy.transform.position = enemySpawnParentObject.position;
        }
    }

    //IEnumerator SpawningEnemies()
    //{

        

    //    yield return new WaitForSeconds(enemySpawnTime);

    //    yield return SpawningEnemies();
    //}

}
