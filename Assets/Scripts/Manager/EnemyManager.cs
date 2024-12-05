using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental.FileFormat;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<Enemy> enemys = new List<Enemy>();
    private static EnemyManager instance = null;

    public bool canSpawn = true;
    public float minSpawnTime;
    public float maxSpawnTime;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnEnemyC());
        
    }
    IEnumerator SpawnEnemyC()
    {
        yield return new WaitForSeconds(5);
        GameObject enemy1 = ObjectPool.Instance.GetObject(ObjectType.EnemyC);
        GameObject enemy2 = ObjectPool.Instance.GetObject(ObjectType.EnemyC);
        enemy1.transform.position = new Vector3(1, 6, 0);
        enemy2.transform.position = new Vector3(-1, 6, 0);
        enemy1.transform.rotation = Quaternion.identity;
        enemy2.transform.rotation = Quaternion.identity;
    }
    IEnumerator SpawnEnemy()
    {
        while (canSpawn)
        {
            ObjectType enemyType = ObjectType.EnemyA + Random.Range(0, 2);
            GameObject enemy = ObjectPool.Instance.GetObject(enemyType);

            float random_x = Random.Range(-2f, 2f);
            enemy.transform.position = new Vector3(random_x, 6, 0);
            enemy.transform.rotation = Quaternion.identity;

            float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

            enemys.Add(enemy.GetComponent<Enemy>());

            yield return new WaitForSeconds(spawnTime);
        }
    }
    public EnemyManager asdf()
    {
        if (instance == null)
        {
            return null;
        }
        return instance;
    }
    public static EnemyManager Instance
    {
        get
        {
            if(instance == null)
            {
                return null;
            }
            return instance;
        }
    }
}
