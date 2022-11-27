using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemy;


    void Start()
    {
        StartCoroutine(EnemySpawner(enemy));
    }

    void Update()
    {
        
    }

    IEnumerator EnemySpawner (GameObject enemyType)
    {
        while (true)
        {
            SpawnEnemy(enemyType);
            yield return new WaitForSeconds(1f);
        }
    }

    private void SpawnEnemy(GameObject enemyType)
    {
        Instantiate(enemyType);
    }
}
